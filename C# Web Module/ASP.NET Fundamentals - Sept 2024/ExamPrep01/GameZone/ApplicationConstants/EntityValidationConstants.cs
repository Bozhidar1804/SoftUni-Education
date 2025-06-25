namespace GameZone.ApplicationConstants
{
    public static class EntityValidationConstants
    {
        public static class Game
        {
            public const int GameTitleMinLength = 2;
            public const int GameTitleMaxLength = 50;
            public const int GameDescriptionMinLength = 10;
            public const int GameDescriptionMaxLength = 500;
            public const string GameReleasedOnFormat = " yyyy-MM-dd";
        }

        public static class Genre
        {
            public const int GenreNameMinLength = 3;
            public const int GenreNameMaxLength = 25;
        }
    }
}
