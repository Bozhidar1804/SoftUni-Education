using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person1 = new Person("Pesho", 12);

            var person = new Person
            (
                null,
                -1
            );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
            Console.WriteLine(Validator.IsValid(person1));
        }
    }
}
