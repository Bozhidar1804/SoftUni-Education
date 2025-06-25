using System.Security.Cryptography;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ");

                string firstName = command[0];
                string lastName = command[1];
                float grade = float.Parse(command[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            List<Student> descendedStudents = new List<Student>(students.OrderByDescending(g => g.Grade));

            foreach(Student student in descendedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, float grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public float Grade { get; set; }
    }
}