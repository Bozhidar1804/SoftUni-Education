using System.Globalization;

using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using static CinemaApp.Common.EntityValidationConstants.Movie;
using Microsoft.EntityFrameworkCore.Diagnostics;
using CinemaApp.Web.ViewModels.Cinema;

namespace CinemaApp.Services.Data
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie, Guid> movieRepository;
		private readonly IRepository<Cinema, Guid> cinemaRepository;

		public MovieService(IRepository<Movie, Guid> movieRepository, IRepository<Cinema, Guid> cinemaRepository)
        {
            this.movieRepository = movieRepository;
            this.cinemaRepository = cinemaRepository;

		}

        public async Task<IEnumerable<AllMoviesIndexViewModel>> IndexGetAllMoviesAsync()
        {
            IEnumerable<AllMoviesIndexViewModel> allMovies = await movieRepository
                .GetAllAttached()
                .Select(m => new AllMoviesIndexViewModel()
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(ReleaseDateFormat),
                    Duration = m.Duration.ToString()
                })
                .ToListAsync();

            return allMovies;
        }

        public async Task<bool> CreateMovieAsync(AddMovieInputModel inputModel)
        {
            bool isReleaseDateValid = DateTime
                .TryParseExact(inputModel.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                return false;
            }

            Movie movie = new Movie()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Description = inputModel.Description,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
                ImageUrl = inputModel.ImageUrl
            };

            await this.movieRepository.AddAsync(movie);

            return true;
        }

		public async Task<MovieDetailsViewModel> DetailsForMovie(Guid movieGuid)
		{
            Movie? movie = await movieRepository
                .GetByIdAsync(movieGuid);

            MovieDetailsViewModel? detailsViewModel = null;
            if (movie != null)
            {
                detailsViewModel = new MovieDetailsViewModel()
				{
					Title = movie.Title,
					Genre = movie.Genre,
					ReleaseDate = movie.ReleaseDate.ToString(ReleaseDateFormat),
					Duration = movie.Duration.ToString(),
					Description = movie.Description,
					Director = movie.Director
				};
			}

            return detailsViewModel;
		}

		public async Task<AddMovieToCinemaProgramInputModel> LinkMovieToProgram(Guid movieId)
		{
            Movie? movie = await movieRepository.GetByIdAsync(movieId);

            AddMovieToCinemaProgramInputModel? viewModel = null;
            if (movie != null)
            {
				viewModel = new AddMovieToCinemaProgramInputModel()
				{
					MovieId = movieId!.ToString(),
					MovieTitle = movie.Title,
					Cinemas = await this.cinemaRepository
                    .GetAllAttached()
				    .Include(c => c.CinemaMovies)
				    .ThenInclude(cm => cm.Movie)
				    .Select(c => new CinemaCheckBoxItemInputModel()
				    {
				    	Id = c.Id.ToString(),
				    	Name = c.Name,
				    	Location = c.Location,
				    	IsSelected = c.CinemaMovies
				    	.Any(cm => cm.Movie.Id == movieId)
			    	}).ToArrayAsync()
				};
			}

            return viewModel;
		}
	}
}
