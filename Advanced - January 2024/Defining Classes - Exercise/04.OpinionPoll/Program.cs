using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(input[0], int.Parse(input[1]));
                people.Add(person);
            }

            List<Person> filteredList = people.OrderBy(p => p.Name).Where(p => p.Age > 30).ToList();
            foreach (Person person in filteredList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}