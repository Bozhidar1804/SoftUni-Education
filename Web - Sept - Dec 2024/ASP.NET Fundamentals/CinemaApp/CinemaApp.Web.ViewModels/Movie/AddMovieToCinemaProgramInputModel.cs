using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Web.ViewModels.Cinema;

namespace CinemaApp.Web.ViewModels.Movie
{
    using static CinemaApp.Common.EntityValidationConstants.Movie;
    using static CinemaApp.Common.EntityValidationConstants.Cinema;
    public class AddMovieToCinemaProgramInputModel
    {
        [Required]
        public string MovieId { get; set; } = null!;
        [Required]
        [MaxLength(TitleMaxLength)]
        public string MovieTitle { get; set; } = null!;
        public IList<CinemaCheckBoxItemInputModel> Cinemas { get; set; } = new List<CinemaCheckBoxItemInputModel>();
    }
}
