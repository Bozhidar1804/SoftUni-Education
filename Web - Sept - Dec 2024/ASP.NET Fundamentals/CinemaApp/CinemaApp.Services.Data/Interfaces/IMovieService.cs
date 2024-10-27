using CinemaApp.Web.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMoviesIndexViewModel>> IndexGetAllMoviesAsync();

        Task<bool> CreateMovieAsync(AddMovieInputModel inputModel);

        Task<MovieDetailsViewModel> DetailsForMovie(Guid id);

        Task<AddMovieToCinemaProgramInputModel> LinkMovieToProgram(Guid id);
    }
}
