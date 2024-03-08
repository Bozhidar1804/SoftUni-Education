using _04WildFarm.Animals;
using _04WildFarm.Interfaces;

namespace _04WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICollection<IAnimal> animals = new List<IAnimal>();
            FoodCreator foodCreator = new FoodCreator();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                IAnimal currentAnimal = null;
                string[] animal = command.Split(" ");
                if (animal[0] == "Owl")
                {
                    Owl owl = new Owl(animal[1], double.Parse(animal[2]), int.Parse(animal[3]));
                    currentAnimal = owl;
                } else if (animal[0] == "Hen")
                {
                    Hen hen = new Hen(animal[1], double.Parse(animal[2]), int.Parse(animal[3]));
                    currentAnimal = hen;
                } else if (animal[0] == "Mouse")
                {
                    Mouse mouse = new Mouse(animal[1], double.Parse(animal[2]), animal[3]);
                    currentAnimal = mouse;
                } else if (animal[0] == "Dog")
                {
                    Dog dog = new Dog(animal[1], double.Parse(animal[2]), animal[3]);
                    currentAnimal = dog;
                } else if (animal[0] == "Cat")
                {
                    Cat cat = new Cat(animal[1], double.Parse(animal[2]), animal[3], animal[4]);
                    currentAnimal = cat;
                } else if (animal[0] == "Tiger")
                {
                    Tiger tiger = new Tiger(animal[1], double.Parse(animal[2]), animal[3], animal[4]);
                    currentAnimal = tiger;
                }
                Console.WriteLine(currentAnimal.ProduceSound());

                try
                {
                    animals.Add(currentAnimal);

                    string[] foodArguments = Console.ReadLine().Split(" ");
                    string foodType = foodArguments[0];
                    int quantity = int.Parse(foodArguments[1]);
                    Food currentFood = foodCreator.Create(foodType, quantity);

                    currentAnimal.FeedIt(currentFood);
                } catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}