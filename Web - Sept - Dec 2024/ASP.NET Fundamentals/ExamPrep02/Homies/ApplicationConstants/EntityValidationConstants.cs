namespace Homies.ApplicationConstants
{
    public static class EntityValidationConstants
    {
        public static class Event
        {
            public const int EventNameMinLength = 5;
            public const int EventNameMaxLength = 20;
            public const int EventDescriptionMinLength = 15;
            public const int EventDescriptionMaxLength = 150;
            public const string EventCreatedOnFormat = "yyyy-MM-dd H:mm";
            public const string EventStartFormat = "yyyy-MM-dd H:mm";
            public const string EventEndFormat = "yyyy-MM-dd H:mm";
        }

        public static class Type
        {
            public const int TypeNameMinLength = 5;
            public const int TypeNameMaxLength = 15;
        }
    }
}
