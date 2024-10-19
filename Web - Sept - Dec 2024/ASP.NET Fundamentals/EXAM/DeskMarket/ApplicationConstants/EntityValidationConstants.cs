namespace DeskMarket.ApplicationConstants
{
    public static class EntityValidationConstants
    {

        public static class Product
        {
            public const int ProductNameMinLength = 2;
            public const int ProductNameMaxLength = 60;
            public const int ProductDescriptionMinLength = 10;
            public const int ProductDescriptionMaxLength = 250;
            public const double ProductPriceMinValue = 1.00;
            public const double ProductPriceMaxValue = 3000.00;
            public const string DateAddedOnFormat = "dd-MM-yyyy";

            public const string RequiredErrorMessage = "The field {0} is required.";
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 20;
        }
    }
}
