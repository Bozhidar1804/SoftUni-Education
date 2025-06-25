namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = "";

            while (command != "End")
            {
                command = Console.ReadLine();
                if (command == "End") break;


                string[] commandArr = command.Split(' ');
                string name = commandArr[0];
                int id = int.Parse(commandArr[1]);
                int age = int.Parse(commandArr[2]);

                if (idExists(people, id))
                {
                    foreach(Person person in people)
                    {
                        if (person.ID == id)
                        {
                            person.Name = name;
                            person.Age = age;
                        }
                    }
                } else
                {
                    Person person = new Person(name, id, age);
                    people.Add(person);
                }
            }

            List<Person> orderedPeople = people.OrderBy(x => x.Age).ToList();

            foreach (Person person in orderedPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }

        public static bool idExists (List<Person> people, int id)
        {
            bool result = false;

            foreach (Person person in people)
            {
                if (id == person.ID)
                {
                    result = true;
                }
            }


            return result;
        }
    }

    class Person
    {
        public Person (string name, int id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public string Name { get; set; }

        public int ID { get; set; } 

        public int Age { get; set; }
    }
}