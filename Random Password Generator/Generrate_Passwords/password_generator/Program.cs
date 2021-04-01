using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generrate_Passwords;

namespace password_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Password pass = new Password(8);
            Console.WriteLine(pass.PassWord);
            Console.ReadKey();
        }
    }
}
