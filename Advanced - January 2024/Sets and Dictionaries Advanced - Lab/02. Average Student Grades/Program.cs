using System.Security;
using System.Text;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                }
                students[name].Add(grade);
            }

            foreach (var student in students) 
            {
                decimal currentSum = 0;
                StringBuilder sb = new StringBuilder();
                foreach (decimal grade in student.Value)
                {
                    currentSum += grade;
                    sb.Append($"{grade:F2}" + " ");
                }
                Console.WriteLine($"{student.Key} -> {sb}(avg: {(currentSum / student.Value.Count /* student.Value.Average() */):F2})");
            }
        }
    }
}