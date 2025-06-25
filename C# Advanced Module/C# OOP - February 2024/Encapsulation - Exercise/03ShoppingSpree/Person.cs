using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ShoppingSpree
{
    internal class Person
    {
        private string name;
        private int money;
        private List<Product> products;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public int Money
        {
            get
            {
                return money;
            } private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products { get { return products.AsReadOnly(); } }

        public void AddProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                products.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            } else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} - ");
            if (products.Count > 0)
            {
                foreach (Product product in products)
                {
                    sb.Append($"{product.Name}, ");
                }

                return sb.ToString().Remove(sb.Length - 2);
            } else
            {
                sb.Append("Nothing bought");
                return sb.ToString();
            }
        }
    }
}
