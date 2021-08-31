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
        string x = "";
        Random random = new Random();
        ObservableCollection<string> history = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Password pass = new Password(random.Next(8, 21));
                pass.Selected_four(Number.IsChecked, Upper.IsChecked, Lower.IsChecked, Special.IsChecked);
                xpassword_box.Text = pass.PassWord;
                history.Add(xpassword_box.Text);
            
        }

        private void xhistoryshower_Click(object sender, RoutedEventArgs e)
        {
            xpassword_history_box.ItemsSource = history;
            xpassword_history_box.Visibility = Visibility.Visible;
            xcopyfromhistory.Visibility = Visibility.Visible;

            
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(xpassword_box.Text);
        }

        private void copyfromhistory_Click(object sender, RoutedEventArgs e)
        {
           
            Clipboard.SetText(xpassword_history_box.SelectedItem.ToString());
        }

        private void xpassword_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            x = xpassword_box.Text;
            if (x.Length >= 8 && x.Length <= 10)
            {
                xpassword_box.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (x.Length >= 11 && x.Length <= 14)
            {
                xpassword_box.BorderBrush = new SolidColorBrush(Colors.Blue);
            }
            else if (x.Length >= 15 && x.Length <= 20)
            {
                xpassword_box.BorderBrush = new SolidColorBrush(Colors.Green);
            }
        }
    }
}
