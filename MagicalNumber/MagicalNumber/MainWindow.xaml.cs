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

namespace MagicalNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            random();
           
        }

        private void Submission_Click(object sender, RoutedEventArgs e)
        {
            int[] Board = new int[9];

            int p0 = Convert.ToInt32(Position1.Text);
            Board[0] = p0;
            int p1 = Convert.ToInt32(Position2.Text);
            Board[1] = p1;
            int p2 = Convert.ToInt32(Position3.Text);
            Board[2] = p2;
            int p3 = Convert.ToInt32(Position4.Text);
            Board[3] = p3;
            int p4 = Convert.ToInt32(Position5.Text);
            Board[4] = p4;
            int p5 = Convert.ToInt32(Position6.Text);
            Board[5] = p5;
            int p6 = Convert.ToInt32(Position7.Text);
            Board[6] = p6;
            int p7 = Convert.ToInt32(Position8.Text);
            Board[7] = p7;
            int p8 = Convert.ToInt32(Position9.Text);
            Board[8] = p8;
            if (top(p0, p1, p2) && top(p3,p4,p5) && top(p6,p7,p8) && top(p0,p4,p8) && top(p2,p4,p6) && top(p0,p3,p6) && top(p1,p4,p7) && top(p2,p5,p8))
                MessageBox.Show("Win");
            else
                MessageBox.Show("lose");
            
        }

        public static bool top(int a, int b, int c)
        {
            return  a + b + c == 15;
        }

        #region Mouse Enter Events
        #region Position One-----Text Box
        private void Position1_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position1.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position1_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position1.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Two-----Text Box
        private void Position2_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position2.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position2_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position2.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Three-----Textbox
        private void Position3_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position3.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position3_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position3.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Four-----Textbox
        private void Position4_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position4.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position4_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position4.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Five-----Textbox
        private void Position5_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position5.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position5_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position5.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Six-----Textbox
        private void Position6_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position6.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position6_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position6.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Seven-----Textbox
        private void Position7_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position7.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position7_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position7.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Eigth-----Textbox
        private void Position8_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position8.Background = new SolidColorBrush(Colors.Bisque);
        }
        private void Position8_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position8.Background = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Position Nine-----Textbox
        private void Position9_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Position9.Background = new SolidColorBrush(Colors.Bisque);
        }

        private void Position9_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Position9.Background = new SolidColorBrush(Colors.White);
        }
        #endregion
        
        #endregion

        //Random Number
        public void random()
        {
            Random random = new Random();
            int a = (int)random.Next(1, 5);
            if (a == 1)
            {
                Position5.Text = "5";
                Position3.Text = "6";
                Position7.Text = "4";
            }
            else if (a == 2)
            {
                Position5.Text = "5";
                Position1.Text = "8";
                Position9.Text = "2";
            }
            else if (a == 3)
            {
                Position5.Text = "5";
                Position4.Text = "3";
                Position6.Text = "7";
            }
            else if (a == 4)
            {
                Position5.Text = "5";
                Position4.Text = "9";
                Position6.Text = "1";
            }
        }

 
        //Digit
        public bool Digit(string ch)
        {
            bool x = false;
            try
            {
                int a = int.Parse(ch);
                if (a > 0 && a <= 9)
                {
                    x = true;
                }

            }
            catch
            {
 
            }
            return x;
        }

        #region TextBox_Check
        private void Position1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position1.Text) == false)
            {
                Position1.Text = "";
            }
        }

        private void Position2_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position2.Text) == false)
            {
                Position2.Text = "";
            }
        }

        private void Position3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position3.Text) == false)
            {
                Position3.Text = "";
            }
        }

        private void Position4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position4.Text) == false)
            {
                Position4.Text = "";
            }
        }

        private void Position5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position5.Text) == false)
            {
                Position5.Text = "";
            }
        }

        private void Position6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position6.Text) == false)
            {
                Position6.Text = "";
            }
        }

        private void Position7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position7.Text) == false)
            {
                Position7.Text = "";
            }
        }

        private void Position8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position8.Text) == false)
            {
                Position8.Text = "";
            }
        }

        private void Position9_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit(Position9.Text) == false)
            {
                Position9.Text = "";
            }
        }
        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Position1.Text = "";
            Position2.Text = "";
            Position3.Text = "";
            Position4.Text = "";
            Position5.Text = "";
            Position6.Text = "";
            Position7.Text = "";
            Position8.Text = "";
            Position9.Text = "";
            random();
        }
    }
}
