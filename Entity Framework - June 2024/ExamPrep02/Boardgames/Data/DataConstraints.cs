using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data
{
    public class DataConstraints
    {
        // Boardgame
        public const byte BoardgameNameMinLength = 10;
        public const byte BoardgameNameMaxLength = 20;
        public const int BoardgameRatingMinValue = 1;
        public const int BoardgameRatingMaxValue = 10;
        public const int BoardGameYearPublishedMinValue = 2018;
        public const int BoardGameYearPublishedMaxValue = 2023;

        // Seller
        public const byte SellerNameMinLength = 5;
        public const byte SellerNameMaxLength = 20;
        public const byte AddressNameMinLength = 2;
        public const byte AddressNameMaxLength = 30;

        // Creator
        public const byte CreatorFirstNameMinLength = 2;
        public const byte CreatorFirstNameMaxLength = 7;
        public const byte CreatorLastNameMinLength = 2;
        public const byte CreatorLastNameMaxLength = 7;
    }
}
