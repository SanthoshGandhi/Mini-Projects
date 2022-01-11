using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSync
{
    class Program
    {
        static void Main(string[] args)
        {
            string SourcePath = @"G:\My Drive\MicroFinance";
            string LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BackupFiles\\MicroFinanceBackup\\MicroFinance";
            Console.WriteLine("Processing");
            Sync sync = new Sync(SourcePath, LocalPath);
            Console.ReadKey();
        }
       
       
    }
    
}
