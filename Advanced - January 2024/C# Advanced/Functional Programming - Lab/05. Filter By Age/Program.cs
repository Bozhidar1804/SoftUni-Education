using System.Security.Cryptography;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = ReadPeople(n);

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Func<Person, string> printer = CreatePrinter(format);
            PrintFilteredPeople(people, filter, printer);

            static Func<Person, bool> CreateFilter (string condition, int ageThreshold)
            {
                if (condition == "younger")
                {
                    return p => p.Age < ageThreshold;
                } else if (condition == "older")
                {
                    return p => p.Age >= ageThreshold;
                }

                return null;
            }

            static Func<Person, string> CreatePrinter (string format)
            {
                if (format == "name")
                {
                    return p => $"{p.Name}";
                } else if (format == "age")
                {
                    return p => $"{p.Age}";
                } else if (format == "name age")
                {
                    return p => $"{p.Name} - {p.Age}";
                }

                return null;
            }
        }

        static List<Person> ReadPeople(int n)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                string name = command[0];
                int age = int.Parse(command[1]);
                Person person = new Person(name, age);

                people.Add(person);
            }

            return people;
        }

        public static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Func<Person, string> printer)
        {
            foreach (Person person in people)
            {
                if (filter(person))
                {
                    Console.WriteLine(printer(person));
                }
            }
        }
    }

    class Person
    {
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

       
    }
}