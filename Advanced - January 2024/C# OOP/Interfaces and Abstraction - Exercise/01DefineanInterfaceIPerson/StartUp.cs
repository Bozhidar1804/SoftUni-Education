namespace PersonInfo
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Citizen citizen = new Citizen(name, age);
            Console.WriteLine(citizen.Name);
            Console.WriteLine(citizen.Age);
        }
    }
}