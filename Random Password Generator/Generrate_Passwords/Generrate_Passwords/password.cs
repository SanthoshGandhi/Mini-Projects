using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generrate_Passwords
{
    public class Password
    {
        private List<char> numbers = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private List<char> upper_case = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private List<char> lower_case = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private List<char> special_case = new List<char> { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '{', '[', '}', ']', '|', '/', ',', ':', ';', '<', '>', '.', '?', '/' };
        private int Length;
        private string _password;
        Random random = new Random();
        public string PassWord
        {
            get 
            {
                return _password;
            }
           
        }
        public Password(int length)
        {
            Length = length;
            _password = Random_password();
        }

        public string Random_password()
        {
            string password="";
            for (int i = 0; i < Length; i++)
            {
                int a = random.Next(1, 5);
                if (a == 1)
                {
                    password += numbers[random_number()] ;
                }
                else if (a == 2)
                {
                    password += upper_case[upper_case_number()];
                }
                else if (a == 3)
                {
                    password += lower_case[lower_case_number()];
                }
                else if (a == 4)
                {
                    password += special_case[Special_case_number()];
                }
            }
            return password;
        }

        private int random_number()
        {
            //Random random = new Random();
            return random.Next(0, 9);
        }
        private int upper_case_number()
        {
            //Random random = new Random();
            return random.Next(0, 26);
        }
        private int lower_case_number()
        {
            //Random random = new Random();
            return random.Next(0, 26);
        }
        private int Special_case_number()
        {
            //Random random = new Random();
            return random.Next(0, 30);
        }

    }
}
