﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common
{
    public static class EntityValidationMessages
    {
        public static class Movie
        {
            public const string TitleRequiredMessage = "Movie title is required.";
			public const string GenreRequiredMessage = "Genre is required.";
			public const string ReleaseDateRequiredMessage = "Release date is required in the format MM/yyyy.";
			public const string DirectorNameRequiredMessage = "Director name is required.";
			public const string DurationRequiredMessage = "Please specify the movie duration.";
		}
    }
}