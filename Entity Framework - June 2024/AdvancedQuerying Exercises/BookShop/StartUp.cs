namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            DbInitializer.ResetDatabase(dbContext);

            Console.WriteLine(GetMostRecentBooks(dbContext));
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

        // Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    Price = b.Price.ToString("f2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
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

        // Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime input = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < input)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    EditionType = b.EditionType.ToString(),
                    Price = b.Price.ToString("f2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return String.Join(Environment.NewLine, authors);
        }

        // Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();

            string[] books = context.Books
                .Where(b => b.Title.ToLower().Contains(input))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profits = c.CategoryBooks
                                .Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profits)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var pair in result)
            {
                sb.AppendLine($"{pair.CategoryName} ${pair.Profits:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesWithBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                            .OrderByDescending(b => b.Book.ReleaseDate)
                            .Take(3)
                            .Select(b => new
                            {
                                BookTitle = b.Book.Title,
                                BookYear = b.Book.ReleaseDate.Value.Year
                            })
                            .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var c in categoriesWithBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");
                foreach (var book in c.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncrease = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in booksToIncrease)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int count = booksToRemove.Count();

            foreach (var book in booksToRemove)
            {
                context.Remove(book);
            }

            context.SaveChanges();

            return count;
        }

    }
}


