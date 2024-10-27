using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using System.Globalization;

using static CinemaApp.Common.EntityValidationConstants.Movie;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;


namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly CinemaDbContext dbContext;
        private readonly IMovieService movieService;

        public MovieController(CinemaDbContext dbContext, IMovieService movieService)
        {
            this.dbContext = dbContext;
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AllMoviesIndexViewModel> allMovies = await movieService.IndexGetAllMoviesAsync();

            return View(allMovies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                // Render the same form with user entered values + model errors
                return View(inputModel);
            }

            bool creationResult = await this.movieService.CreateMovieAsync(inputModel);
            if (!creationResult)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), String.Format("The Released Date must be in the following format: {0}", ReleaseDateFormat));
                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid movieGuid = Guid.Empty;
            bool isGuidIdValid = IsGuidValid(id, ref movieGuid);

            if (!isGuidIdValid)
            {
                return RedirectToAction(nameof(Index));
            }
            
            MovieDetailsViewModel movieDetailsViewModel = await this.movieService.DetailsForMovie(movieGuid);

            if (movieDetailsViewModel == null)
            {
                // Non-existing movie guid
                return RedirectToAction(nameof(Index));
            }

            return View(movieDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddToProgram(string? movieId)
        {
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(movieId, ref movieGuid);
            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaProgramInputModel viewModel = await this.movieService.LinkMovieToProgram(movieGuid);

            if (viewModel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaProgramInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid movieGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(model.MovieId, ref movieGuid);
            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await dbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == movieGuid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var existingAssignments = await dbContext.CinemasMovies
                    .Where(cm => cm.MovieId.ToString() == model.MovieId)
                    .ToListAsync();
            dbContext.RemoveRange(existingAssignments);

            ICollection <CinemaMovie> entitiesToAdd = new List<CinemaMovie>();

            foreach (CinemaCheckBoxItemInputModel cinemaInputModel in model.Cinemas)
            {
                Guid cinemaGuid = Guid.Empty;
                bool isCinemaGuidValid = IsGuidValid(cinemaInputModel.Id, ref cinemaGuid);
                if (!isCinemaGuidValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid CinemaId");
                    return View(model);
                }

                Cinema? cinema = await dbContext.Cinemas
                    .FirstOrDefaultAsync(c => c.Id == cinemaGuid);
                if (cinema == null)
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid Cinema");
                    return View(model);
                }

                if (cinemaInputModel.IsSelected)
                {
                    CinemaMovie cinemaMovie = new CinemaMovie()
                    {
                        Cinema = cinema,
                        Movie = movie
                    };

                    entitiesToAdd.Add(cinemaMovie);
                }
            }

            await dbContext.CinemasMovies.AddRangeAsync(entitiesToAdd);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Cinema");
        }
    }
}
