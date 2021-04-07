 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Calculator
{
    class Program
    {
        public static int finsh;
        public static void calc()
        {
            while (finsh != 1)
            {
                Console.WriteLine("Enter the number : ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the number : ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter + for Addition.");
                Console.WriteLine("Enter - for Substraction.");
                Console.WriteLine("Enter * for Multiplication.");
                Console.WriteLine("Enter / for Division.");
                Console.WriteLine("Enter % for Modolus.");
                Console.WriteLine("Enter ^ for Power");
                char calc = Convert.ToChar(Console.ReadLine());
                if (calc == '+')
                {
                    Console.WriteLine(Add(a, b));
                }
                else if (calc == '-')
                {
                    Console.WriteLine(Sub(a, b));
                }
                else if (calc == '*')
                {
                    Console.WriteLine(Mul(a, b));
                }
                else if (calc == '/')
                {
                    Console.WriteLine(Div(a, b));
                }
                else if (calc == '%')
                {
                    Console.WriteLine(Mod(a, b));
                }
                else if (calc == '^')
                {
                    Console.WriteLine(pow(a,b));
                }
                Console.WriteLine("press 1 for exit.");
                Console.WriteLine("press 0 for continue");
                int qiut = Convert.ToInt32(Console.ReadLine());
                if (qiut == 1)
                {
                    finsh = 1;
                }
                else
                {
                    finsh = 0;
                }
            }
        }

        public static int Add(int a,int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }

        public static int Mul(int a, int b)
        {
            return a * b;
        }

        public static double Div(int a, int b)
        {
            return a / b;
        }

        public static double Mod(int a, int b)
        {
            return a % b;
        }

        public static double pow(int a, int b)
        {
            return Math.Pow(a, b);
        }

        //public static double Log(int a int b)
        //{
            
        //}














        static void Main(string[] args)
        {
            calc();
            
        }
    }
}
