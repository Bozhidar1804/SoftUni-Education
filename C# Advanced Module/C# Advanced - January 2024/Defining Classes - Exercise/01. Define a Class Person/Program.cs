namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Bozhidar", 17);
            Person person2 = new Person();
            person2.Name = "Ivan";
            person2.Age = 52;
        }
    }
}