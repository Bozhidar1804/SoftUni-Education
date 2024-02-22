namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

            while (songs.Count >= 0)
            {
                string command = Console.ReadLine();
                if (songs.Count == 0)
                {
                    break;
                }

                if (command == "Play")
                {
                    songs.Dequeue();
                } else if (command.Contains("Add"))
                {
                    string song = command.Substring(4);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    } else
                    {
                        songs.Enqueue(song);
                    }
                } else if (command == "Show")
                {
                    int songsCount = songs.Count;
                    foreach (string song in songs)
                    {
                        if (songsCount == 1)
                        {
                            Console.Write($"{song}");
                            Console.WriteLine();
                            break;
                        }
                        Console.Write($"{song}, ");
                        songsCount--;
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}