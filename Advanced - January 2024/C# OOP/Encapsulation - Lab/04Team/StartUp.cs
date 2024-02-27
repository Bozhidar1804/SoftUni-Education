namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                persons.Add(person);
            }

            Team team = new Team("SoftUni");
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team.ToString());
        }
    }
}