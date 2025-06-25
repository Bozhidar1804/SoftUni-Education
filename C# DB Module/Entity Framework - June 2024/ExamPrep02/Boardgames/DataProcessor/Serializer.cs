namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creatorsToExport = context.Creators
                .Where(c => c.Boardgames.Any())
                .AsEnumerable()
                .Select(c => new ExportCreatorDto()
                {
                    CreatorName = string.Join(" ", c.FirstName, c.LastName),
                    BoardgamesCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames.Select(bg => new ExportXmlBoardgameDto()
                    {
                        BoardgameName = bg.Name,
                        BoardgameYearPublished = bg.YearPublished
                    })
                    .OrderBy(bg => bg.BoardgameName)
                    .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Creators";

            return xmlHelper.Serialize(creatorsToExport, xmlRoot);
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellersToExport = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => (bs.Boardgame.YearPublished >= year) && (bs.Boardgame.Rating <= rating)))
                .Select(s => new ExportSellerDto()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers.Where(s => s.Boardgame.YearPublished >= year && s.Boardgame.Rating <= rating)
                                 .Select(s => new ExportJsonBoardgameDto()
                                 {
                                     Name = s.Boardgame.Name,
                                     Rating = s.Boardgame.Rating,
                                     Mechanics = s.Boardgame.Mechanics,
                                     Category = s.Boardgame.CategoryType.ToString()
                                 })
                                 .OrderByDescending(bg => bg.Rating)
                                 .ThenBy(bg => bg.Name)
                                 .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellersToExport, Formatting.Indented);
        }
    }
}