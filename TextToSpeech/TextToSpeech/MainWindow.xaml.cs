using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;
using Microsoft.Win32;
using TextToSpeech.Modal;

namespace TextToSpeech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Speech speech = new Speech();
        public MainWindow()
        {
            InitializeComponent();
            ContentBox.Focus();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ContentBox.Text))
            {
                speech.StartSpeech(ContentBox.Text, IsSpellout(), voiceGender());
            }
            else
            {
                MessageBox.Show("Please Enter the Text or Select the text", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public VoiceGender voiceGender()
        {
            if(Voiceselect.SelectedIndex==0)
            {
                return VoiceGender.Male;
            }
            return VoiceGender.Female;
        }

        public bool IsSpellout()
        {
            if(splout.IsChecked==true)
            {
                return true;
            }
            return false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want to Close the Application.", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Information)==MessageBoxResult.OK)
            {
                Application.Current.MainWindow.Close();
            }
            else
            {
                ContentBox.Text = "";
            }
            
            
            //Application.Current.MainWindow.Close();
        }

        private void Uploadfromfile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDlg.Title = "Choose Text File";
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                string FileFrom = openFileDlg.FileName;
                var FilePath = FileFrom.Split('\\');
                string FileName = FilePath[FilePath.Length - 1];
                ContentBox.Text= speech.FiletoReader(FileFrom);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ContentBox.Text = "";
        }
    }
}
