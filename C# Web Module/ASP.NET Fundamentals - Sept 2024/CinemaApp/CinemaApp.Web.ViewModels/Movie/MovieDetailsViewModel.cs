using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class MovieDetailsViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
		public string Director { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
