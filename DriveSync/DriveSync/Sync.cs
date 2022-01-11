using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace DriveSync
{
    class Sync
    {
        public static string connectionstring = "Data Source=.;Initial Catalog=AutomatedSystem;Integrated Security=True";

        public string SourcePath;
        public string LocalPath;
        public DateTime Date;
        public string FileSize;
        public int FileCount;

        public Sync(string sourceDirectory, string targetDirectory)
        {
            SourcePath = sourceDirectory;
            LocalPath = targetDirectory;
            if (CheckNet())
            {
                if (DateCheck())
                {
                    Copy(SourcePath, LocalPath);
                    Console.WriteLine("Backup Complete.");
                }
                else
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("Check Your Internet Connection");
            }
        }

        public void Copy(string sourceDirectory, string targetDirectory)
        {
            var Source = new DirectoryInfo(sourceDirectory);
            var Target = new DirectoryInfo(targetDirectory);
           
                if (!Directory.Exists(LocalPath))
                {
                    CopyAll(Source, Target);
                    double size = (double)getsize(Target) / 1073741824;
                    FileSize = string.Format("{0:0.00}", size);
                    FileCount = count;
                    CompressFile();
                }
                else
                {
                    ReplaceModifiedFiles(sourceDirectory, targetDirectory);
                    double size = (double)getsize(Target) / 1073741824;
                    FileSize = string.Format("{0:0.00}", size);
                    FileCount = count;
                    CompressFile();
                    InsertFile();
                }
            
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
           
                Directory.CreateDirectory(target.FullName);

                foreach (FileInfo fi in source.GetFiles())
                {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }

                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
        }


        public void ReplaceModifiedFiles(string mainpath,string localpath)
        {
            Dictionary<string, Filemodel> DriveFiles = ModifiedFilesDate(mainpath);
            Dictionary<string, Filemodel> Localfiles = ModifiedFilesDate(localpath);
            DirectoryInfo main = new DirectoryInfo(mainpath);
            DirectoryInfo local = new DirectoryInfo(localpath);

            foreach (KeyValuePair<string, Filemodel> x in DriveFiles)
            {
                if (Localfiles.ContainsKey(x.Key))
                {
                    if (x.Value.modifieddate > Localfiles[x.Key].modifieddate)
                    {
                        FileInfo mainsource = new FileInfo(x.Value.filepath);
                        FileInfo localsource = new FileInfo(Localfiles[x.Key].filepath);

                        mainsource.CopyTo(Localfiles[x.Key].filepath, true);
                    }
                }
                else
                {
                    foreach (FileInfo item in main.GetFiles())
                    {
                        if (x.Key == item.Name)
                        {
                            item.CopyTo(Path.Combine(localpath, x.Key), true);
                            break;
                        }
                    }
                }
            }

            foreach (DirectoryInfo item in main.GetDirectories())
            {
                string secondpath = "";
                string temp = Path.Combine(local.FullName, item.Name);
                if (Directory.Exists(temp))
                {
                    foreach (DirectoryInfo item2 in local.GetDirectories())
                    {
                        if (item.Name == item2.Name)
                        {
                            secondpath = item2.FullName;
                            break;
                        }
                    }
                }
                else
                {
                    secondpath = temp;
                    Directory.CreateDirectory(secondpath);
                }
                ReplaceModifiedFiles(item.FullName, secondpath);
            }
        }


        public Dictionary<string, Filemodel> ModifiedFilesDate(string path)
        {
            Dictionary<string, Filemodel> Dic = new Dictionary<string, Filemodel>();
            DirectoryInfo info = new DirectoryInfo(path);
            foreach (FileInfo item in info.GetFiles())
            {
                Dic.Add(item.Name, new Filemodel { filepath = item.FullName, modifieddate = item.LastAccessTime });
            }
            return Dic;
        } 

        static int count = 0;
        public long getsize(DirectoryInfo path)
        {
            long totalSizeOfDir = 0;

            FileInfo[] allFiles = path.GetFiles();

            foreach (FileInfo file in allFiles)
            {
                totalSizeOfDir += file.Length;
                count++;
            }

            DirectoryInfo[] subFolders = path.GetDirectories();
            foreach (DirectoryInfo dir in subFolders)
            {
                totalSizeOfDir += getsize(dir);
            }
            return totalSizeOfDir;
        }

        //public void RemoveDeletedFiles(string sourcepath, string localpath)
        //{
        //    DirectoryInfo source = new DirectoryInfo(sourcepath);
        //    DirectoryInfo local = new DirectoryInfo(localpath);

        //    foreach (FileInfo info in local.GetFiles())
        //    {
        //        string temp = Path.Combine(source.FullName, info.Name);
        //        if (!File.Exists(temp))
        //        {
        //            File.Delete(info.FullName);
        //        }
        //    }

        //    foreach(DirectoryInfo item in local.GetDirectories())
        //    {
        //        string temp = Path.Combine(source.FullName, item.Name);
        //        if(!Directory.Exists(temp))
        //        {
        //            Directory.Delete(item.FullName);
        //        }
        //        else
        //        {
        //            RemoveDeletedFiles(temp, item.FullName);
        //        }
        //  }



        public void CompressFile()
        {
            Date = DateTime.Now;
            string filename = string.Format("{0}({1:dd-MM-yyyy}).7z", "MFBackup ", Date);
            string zipPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BackupFiles\\", filename);

            if (File.Exists(zipPath))
            {
                Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BackupFiles\\", "*.7z").ToList().ForEach(x => File.Delete(x));
                ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BackupFiles\\MicroFinanceBackup", zipPath);
            }
            else
            {
                ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BackupFiles\\MicroFinanceBackup", zipPath);
            }
        }


        public void InsertFile()
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into BackupFileDetails(Date,Size,FilesCount) values('"+Date.ToString("MM-dd-yyyy")+"','"+FileSize+"','"+FileCount+"')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool DateCheck()
        {
            bool Flag = false;
            DateTime lastDate;
            DateTime Todaydate = DateTime.Now;
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select Count(Date) from BackupFileDetails";
            if ((int)cmd.ExecuteScalar() == 0)
            {
                return Flag = true;
            }
            else
            {
                cmd.CommandText = "Select Max(Date) from BackupFileDetails";
                lastDate = (DateTime)cmd.ExecuteScalar();
            }
            //cmd.CommandText = "select Day from BackupDay";
            //int Day = (int)cmd.ExecuteScalar();
            TimeSpan diff = Todaydate.Subtract(lastDate);
            int days = diff.Days;
            if (days > 7)
            {
                Flag = true;
            }
            con.Close();
            return Flag;
        }



        private bool CheckNet()
        {
            bool flag = false;
            try
            {
                Ping myPing = new Ping();
                String host = "www.google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }

            return flag;
        }


    }
    public class Filemodel
    {
        public string filepath { get; set; }
        public DateTime modifieddate { get; set; }
    }
}
