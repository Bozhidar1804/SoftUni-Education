namespace _03ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] inputPeople = Console.ReadLine().Split(";");
            foreach (string inputtedPerson in inputPeople)
            {
                try
                {
                    string[] splitted = inputtedPerson.Split("=");
                    string name = splitted[0];
                    int money = int.Parse(splitted[1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                } catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            string[] inputProducts = Console.ReadLine().Split(";");
            foreach (string inputtedProduct in inputProducts)
            {
                try
                {
                    if (string.IsNullOrEmpty(inputtedProduct))
                    {
                        continue;
                    }
                    string[] splitted = inputtedProduct.Split("=");
                    string name = splitted[0];
                    int cost = int.Parse(splitted[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                } catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splittedCommand = command.Split(" ");
                string personName = splittedCommand[0];
                string productName = splittedCommand[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);
                if (person is not null && product is not null)
                {
                    person.AddProduct(product);
                }
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}