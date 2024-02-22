using System.Text;

namespace _01WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> worms = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Queue<int> holes = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int matches = 0;
            bool wormIsRemoved = false;

            while (worms.Count > 0 && holes.Count > 0)
            {
                int worm = worms.Peek();
                int hole = holes.Peek();

                if (worm == hole)
                {
                    worms.Pop();
                    holes.Dequeue();
                    matches++;
                } else
                {
                    holes.Dequeue();
                    int wormConvert = worms.Pop() - 3;
                    if (wormConvert <= 0) 
                    {
                        wormIsRemoved = true;
                    } else if (wormConvert > 0)
                    {
                        worms.Push(wormConvert);
                    }
                }
            }

            if (matches > 0)
            {
                Console.WriteLine($"Matches: {matches}");
            } else
            {
                Console.WriteLine("There are no matches.");
            }

            if (worms.Count == 0 && !wormIsRemoved)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            } else if (worms.Count == 0 && wormIsRemoved)
            {
                Console.WriteLine("Worms left: none");
            } else if (worms.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Worms left: ");
                foreach (int worm in worms)
                {
                    sb.Append($"{worm}, ");
                }
                string result = sb.ToString().Remove(sb.Length - 2);
                Console.WriteLine(result);
            }

            if (holes.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            } else if (holes.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Holes left: ");
                foreach (int hole in holes)
                {
                    sb.Append($"{hole}, ");
                }
                string result = sb.ToString().Remove(sb.Length - 2);
                Console.WriteLine(result);
            }
        }
    }
}