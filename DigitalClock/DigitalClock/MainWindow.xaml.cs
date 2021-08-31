using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DigitalClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeZone tz = new TimeZone();
        List<string> zoneList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            var v = TimeZoneInfo.GetSystemTimeZones();
            foreach(var a in v)
            {
                zoneList.Add(a.StandardName);
            }
            regionbox.ItemsSource = zoneList;
            regionbox.SelectedItem = "India Standard Time";
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            DateAssign();
        }

        public void DateAssign()
        {
             tz.TimeConverter(regionbox.SelectedItem.ToString());
            AmPm.Text = tz.Date.ToString("         tt");
            Time.Text = tz.Hourconvert(tz.Hour) + ":" + tz.Minutesconvert(tz.Minute) + ":" + tz.Secondconvert(tz.Second);
            Date.Text = tz.Date.Day.ToString() + ":" + tz.Date.Month.ToString() + ":" + tz.Date.Year.ToString();
            Day.Text = tz.Date.DayOfWeek.ToString();
        }

        private void regionbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tz.Zone = regionbox.SelectedItem.ToString();
        }
        }
}
