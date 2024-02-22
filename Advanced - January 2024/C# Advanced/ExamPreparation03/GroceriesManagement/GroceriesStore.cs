using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }
        
        public GroceriesStore (int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity && !Stall.Contains(product))
            {
                Stall.Add(product);
            }
        }

        public bool RemoveProduct(string name)
        {
            Product productFind = Stall.Find(p => p.Name == name);
            if (productFind != null)
            {
                Stall.Remove(productFind);
                return true;
            }
            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            string result = "";
            Product product = Stall.Find(p => p.Name == name);
            if (product != null)
            {
                double totalPrice = product.Price * quantity;
                Turnover += totalPrice;
                result = $"{product.Name} - {totalPrice:F2}$";
            } else if (product == null)
            {
                result = "Product not found";
            }
            return result;
        }

        public string GetMostExpensive()
        {
            string result = "";
            Product product = Stall.MaxBy(p => p.Price);
            result = product.ToString();
            return result;
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Groceries Price List:");
            foreach (Product product in Stall)
            {
                sb.AppendLine(product.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
