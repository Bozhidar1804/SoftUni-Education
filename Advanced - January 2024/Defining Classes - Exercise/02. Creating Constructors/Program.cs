using DefiningClasses;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person person1 = new Person(15);
            Person person2 = new Person("Ivan", 21);
        }
    }
}