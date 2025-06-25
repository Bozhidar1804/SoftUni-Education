using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ValidationAttributes
{
    public class Person
    {
        public const int minValue = 12;
        public const int maxValue = 90;
        [MyRequired]
        public string FullName { get; set; }

        [MyRange(minValue, maxValue)]
        public int Age { get; set; }
        public Person (string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
    }
}
