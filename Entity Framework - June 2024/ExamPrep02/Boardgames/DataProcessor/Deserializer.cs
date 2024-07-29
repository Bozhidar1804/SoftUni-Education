namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Utilities;
    using Boardgames.DataProcessor.ImportDto;
    using System.Xml.Serialization;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Creators";

            ImportCreatorDto[] creatorDtos = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, xmlRoot);

            ICollection<Creator> creatorsToImport = new List<Creator>();

            foreach (ImportCreatorDto dto in creatorDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Boardgame> newBoardgames = new List<Boardgame>();

                foreach (ImportBoardgameDto boardgameDto in dto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame newBoardgame = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    };

                    newBoardgames.Add(newBoardgame);
                }

                Creator newCreator = new Creator()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Boardgames = newBoardgames
                };

                sb.AppendLine(String.Format(SuccessfullyImportedCreator, dto.FirstName, dto.LastName, newBoardgames.Count));
                creatorsToImport.Add(newCreator);
            }

            context.Creators.AddRange(creatorsToImport);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportSellerDto[] sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);
            ICollection<Seller> sellersToImport = new List<Seller>();

            int[] validBoardgameIds = context.Boardgames.Select(b => b.Id).ToArray();

            foreach (ImportSellerDto dto in sellerDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<BoardgameSeller> newBoardgameSellers = new List<BoardgameSeller>();
                Seller newSeller = new Seller()
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Country = dto.Country,
                    Website = dto.Website
                };

                foreach (int id in dto.Boardgames.Distinct())
                {
                    if (!validBoardgameIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller newBoardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = id,
                        Seller = newSeller
                    };

                    newBoardgameSellers.Add(newBoardgameSeller);
                }

                newSeller.BoardgamesSellers = newBoardgameSellers;
                sellersToImport.Add(newSeller);
                sb.AppendLine(String.Format(SuccessfullyImportedSeller, dto.Name, newBoardgameSellers.Count));
            }

            context.Sellers.AddRange(sellersToImport);
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
