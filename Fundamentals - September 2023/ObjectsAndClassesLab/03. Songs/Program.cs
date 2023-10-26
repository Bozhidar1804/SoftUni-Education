namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> playlist = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("_").ToArray();
                string songType = input[0];
                string songName = input[1];
                string songTime = input[2];

                Song song = new Song(songType, songName, songTime);
                playlist.Add(song); 
            }

            string lastLine = Console.ReadLine();

            if (lastLine == "all")
            {
                foreach (Song song in playlist)
                {
                    Console.WriteLine(song.Name);
                }
            } else
            {
                string givenTypeList = lastLine;
                foreach (Song song in playlist)
                {
                    if (song.TypeList == givenTypeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        public Song()
        {

        }

        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}