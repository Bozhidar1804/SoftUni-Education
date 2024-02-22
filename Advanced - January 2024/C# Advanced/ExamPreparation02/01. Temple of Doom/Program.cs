using System.Text;

namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            List<int> challenges = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            while (tools.Count > 0 && substances.Count > 0 && challenges.Count > 0)
            {
                int tool = tools.Peek();
                int substance = substances.Peek();
                int currentResult = tool * substance;
                bool isResolved = false;
                int indexOfResolvedChallenge = 0;

                foreach (int challenge in challenges)
                {
                    if (currentResult == challenge)
                    {
                        isResolved = true;
                        break;
                    }
                    indexOfResolvedChallenge++;
                }

                if (isResolved)
                {
                    tools.Dequeue();
                    substances.Pop();
                    challenges.RemoveAt(indexOfResolvedChallenge);
                } else if (!isResolved)
                {
                    tool++;
                    tools.Dequeue();
                    tools.Enqueue(tool);

                    substance--;
                    if (substance == 0)
                    {
                        substances.Pop();
                    } else
                    {
                        substances.Pop();
                        substances.Push(substance);
                    }
                }
            }

            if (challenges.Count == 0)
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                if (tools.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Tools: ");
                    foreach (int tool in tools)
                    {
                        sb.Append(tool + ", ");
                    }
                    string result = sb.ToString();
                    result = result.Remove(result.Length - 2);
                    Console.WriteLine(result);
                }
                if (substances.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Substances: ");
                    foreach (int substance in substances)
                    {
                        sb.Append(substance + ", ");
                    }
                    string result = sb.ToString();
                    result = result.Remove(result.Length - 2);
                    Console.WriteLine(result);
                }
            } else if (challenges.Count > 0)
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                if (tools.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Tools: ");
                    foreach (int tool in tools)
                    {
                        sb.Append(tool + ", ");
                    }
                    string result = sb.ToString();
                    result = result.Remove(result.Length - 2);
                    Console.WriteLine(result);
                }
                if (substances.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Substances: ");
                    foreach (int substance in substances)
                    {
                        sb.Append(substance + ", ");
                    }
                    string result = sb.ToString();
                    result = result.Remove(result.Length - 2);
                    Console.WriteLine(result);
                }
                if (challenges.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Challenges: ");
                    foreach (int challenge in challenges)
                    {
                        sb.Append(challenge + ", ");
                    }
                    string result = sb.ToString();
                    result = result.Remove(result.Length - 2);
                    Console.WriteLine(result);
                }
            }
        }
    }
}