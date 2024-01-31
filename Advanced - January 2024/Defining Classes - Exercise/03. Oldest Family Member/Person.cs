using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person ()
        {
            name = "No name";
            age = 1;
        }

        public Person (int age) : this()
        {
            this.age = age;
        }

        public Person (string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
