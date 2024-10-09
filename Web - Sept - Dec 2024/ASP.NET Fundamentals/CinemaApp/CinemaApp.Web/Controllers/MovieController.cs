using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using System.Globalization;

using static CinemaApp.Common.EntityValidationConstants.Movie;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly CinemaDbContext dbContext;

        public MovieController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> allMovies = await dbContext.Movies.ToListAsync();
            return View(allMovies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
        {
            bool isReleaseDateValid = DateTime
                .TryParseExact(inputModel.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), String.Format("The Released Date must be in the following format: {0}", ReleaseDateFormat));
            }

            if (!this.ModelState.IsValid)
            {
                // Render the same form with user entered values + model errors
                return View(inputModel);
            }

            Movie movie = new Movie()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Description = inputModel.Description,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
            };

            await this.dbContext.Movies.AddAsync(movie);
            await this.dbContext.SaveChangesAsync();

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
            
            Movie? movie = await dbContext
                .Movies
                .FirstOrDefaultAsync(m => m.Id == movieGuid);

            if (movie == null)
            {
                // Non-existing movie guid
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
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

            Movie? movie = await dbContext.Movies
                .FindAsync(movieGuid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaProgramInputModel viewModel = new AddMovieToCinemaProgramInputModel()
            {
                MovieId = movieId!,
                MovieTitle = movie.Title,
                Cinemas = await dbContext.Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .Select(c => new CinemaCheckBoxItemInputModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location,
                    IsSelected = c.CinemaMovies
                    .Any(cm => cm.Movie.Id == movieGuid)
                }).ToArrayAsync()
            };

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
            ICollection<CinemaMovie> entitiesToRemove = new List<CinemaMovie>();

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
