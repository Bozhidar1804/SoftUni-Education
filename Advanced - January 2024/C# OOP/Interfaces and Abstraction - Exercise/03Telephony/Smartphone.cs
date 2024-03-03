using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string url)
        {
            bool validUrl = true;
            char[] charArr = url.ToCharArray();
            foreach (char c in charArr)
            {
                if (Char.IsDigit(c))
                {
                    validUrl = false;
                    break;
                }
            }

            if (validUrl)
            {
                Console.WriteLine($"Browsing: {url}!");
            } else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}
