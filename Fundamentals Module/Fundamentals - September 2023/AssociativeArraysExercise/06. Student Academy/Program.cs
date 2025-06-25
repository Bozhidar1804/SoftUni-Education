namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> info = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string currentStudent = Console.ReadLine();
                double currentGrade = double.Parse(Console.ReadLine());

                if (!info.ContainsKey(currentStudent))
                {
                    info[currentStudent] = new List<double>();
                    info[currentStudent].Add(currentGrade);
                } else
                {
                    info[currentStudent].Add(currentGrade);
                }
            }

            double average = 0;
            double sum = 0;

            foreach(KeyValuePair<string, List<double>> kvp in info)
            {
                foreach (double grade in kvp.Value)
                {
                    sum += grade;
                }
                average = sum / kvp.Value.Count;

                if (average < 4.50)
                {
                    info.Remove(kvp.Key);
                } else
                {
                    Console.WriteLine($"{kvp.Key} -> {average:F2}");
                }

                average = 0;
                sum = 0;
            }
        }
    }
}