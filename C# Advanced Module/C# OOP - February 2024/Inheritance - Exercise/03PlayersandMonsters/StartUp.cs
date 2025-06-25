namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DarkKnight darkknight = new DarkKnight("Ivan", 31);
            Console.WriteLine(darkknight.ToString());
        }
    }
}