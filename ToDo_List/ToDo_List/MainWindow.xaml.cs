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
using System.Collections.ObjectModel;

namespace ToDo_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> AddingList = new ObservableCollection<string>();
        ObservableCollection<string> finished1 = new ObservableCollection<string>();
        int selectindex;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddingList.Add(ToDoEnterbox.Text);
            ToDobox.ItemsSource = AddingList;
            ToDoEnterbox.Clear();
        }

        private void ToDobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             selectindex = ToDobox.SelectedIndex;
        }

        private void strikeout_Click(object sender, RoutedEventArgs e)
        {

            finished1.Add(AddingList[selectindex]);
            finished.ItemsSource = finished1;
            AddingList.Remove(AddingList[selectindex]);
        }
    }
}
