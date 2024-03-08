using System.Text;

namespace _03Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            List<Card> cards = new List<Card>();

            foreach (var kvp in input)
            {
                string[] kvpArgs = kvp.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Card card = new Card(kvpArgs[0], kvpArgs[1]);
                    cards.Add(card);
                } catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }
            Console.WriteLine(String.Join(" ", cards));
        }
    }

    public class Card
    {
        private string face;
        private string suit;

        private static readonly List<string> Faces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static readonly List<string> Suits = new List<string> { "S", "H", "D", "C" };

        public Card (string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; }
            set
            {
                if (!Faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }

        public string Suit
        {
            get { return suit; }
            set
            {
                if (!Suits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }

        public override string ToString()
        {
            if (this.face != null && this.suit != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(this.Face);
                if (this.Suit == "S")
                {
                    byte[] bytes = Encoding.Default.GetBytes("\u2660");
                    string myString = Encoding.UTF8.GetString(bytes);
                    sb.Append(myString);
                }
                else if (this.Suit == "H")
                {
                    byte[] bytes = Encoding.Default.GetBytes("\u2665");
                    string myString = Encoding.UTF8.GetString(bytes);
                    sb.Append(myString);
                }
                else if (this.Suit == "D")
                {
                    byte[] bytes = Encoding.Default.GetBytes("\u2666");
                    string myString = Encoding.UTF8.GetString(bytes);
                    sb.Append(myString);
                }
                else if (this.Suit == "C")
                {
                    byte[] bytes = Encoding.Default.GetBytes("\u2663");
                    string myString = Encoding.UTF8.GetString(bytes);
                    sb.Append(myString);
                }
                return $"[{sb.ToString()}]";
            }
            return null;
        }
    }
}