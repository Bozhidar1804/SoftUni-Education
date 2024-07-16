namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            DbInitializer.ResetDatabase(dbContext);

            string categories = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(dbContext, categories));
        }

        // Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                string[] bookTitles = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return String.Join(Environment.NewLine, bookTitles);
            }  catch (Exception e)
            {
                return e.Message;
            }
        }

        // Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                   .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                   .OrderBy(b => b.BookId)
                   .Select(b => b.Title)
                   .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            string[] bookTitles = context.Books
                .Where(b => b.BookCategories
                            .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }
    }
}


