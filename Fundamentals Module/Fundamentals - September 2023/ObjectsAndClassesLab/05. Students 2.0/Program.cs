namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string command = "";

            while (command != "end")
            {
                command = Console.ReadLine();
                if (command == "end") break;

                string[] input = command.Split(" ");
                string firstName = input[0];
                string lastName = input[1];
                string age = input[2];
                string homeTown = input[3];

                if (AlreadyExists(firstName, lastName, students))
                {
                    foreach (Student currentStudent in students)
                    {
                        if (currentStudent.FirstName == firstName && currentStudent.LastName == lastName)
                        {
                            currentStudent.Age = age;
                            currentStudent.HomeTown = homeTown;
                        }
                    }
                } else
                {
                    Student student = new Student(firstName, lastName, age, homeTown);
                    students.Add(student);
                }
            }

            string lastLine = Console.ReadLine();

            foreach (Student student in students)
            {
                if (lastLine == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        public static bool AlreadyExists(string firstName, string lastName, List<Student> students)
        {
            bool result = false;
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    result = true;
                }
            }
            return result;
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, string age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Age { get; set; }

        public string HomeTown { get; set; }
    }
}