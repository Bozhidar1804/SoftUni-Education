namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();

            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                if (command[0] == "Rename")
                {
                    article.Rename(command[1]);

                } else if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                } else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }
            }

            article.PrintArticle(article);
        }
    }

    class Article
    {
        public Article (string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Rename(string title)
        {
            Title = title;
        }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void PrintArticle(Article article)
        {
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}