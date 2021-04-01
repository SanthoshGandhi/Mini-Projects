using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Generrate_Passwords;

namespace Random_Password
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> history = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
           
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Password pass = new Password(15);
            xpassword_box.Text = pass.PassWord;
            history.Add(pass.PassWord);
            
        }

        private void xhistoryshower_Click(object sender, RoutedEventArgs e)
        {
            xpassword_history_box.ItemsSource = history;
            xpassword_history_box.Visibility = Visibility.Visible;
            
        }

        private void xpassword_history_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

       
    }
}
