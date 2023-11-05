namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split(" : ");
                string courseName = commandArr[0];
                string currentStudent = commandArr[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(currentStudent);
                } else
                {
                    courses[courseName].Add(currentStudent);
                }
            }

            foreach (KeyValuePair<string, List<string>> kvp in courses)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (string student in kvp.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}