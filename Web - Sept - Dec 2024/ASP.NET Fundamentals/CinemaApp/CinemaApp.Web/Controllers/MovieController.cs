using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using System.Globalization;


namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaDbContext dbContext;

        public MovieController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> allMovies = dbContext.Movies.ToList();
            return View(allMovies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddMovieInputModel inputModel)
        {
            bool isReleaseDateValid = DateTime
                .TryParseExact(inputModel.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), "The Released Date must be in the following format: dd/MM/yyyy");
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

            this.dbContext.Movies.Add(movie);
            this.dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }
            
            Movie? movie = dbContext
                .Movies
                .FirstOrDefault(m => m.Id == guidId);

            if (movie == null)
            {
                // Non-existing movie guid
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
    }
}
