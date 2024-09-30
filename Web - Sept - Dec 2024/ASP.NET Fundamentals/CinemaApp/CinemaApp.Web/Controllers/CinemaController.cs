using CinemaApp.Data;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Web.Controllers
{
	public class CinemaController : BaseController
	{
		private readonly CinemaDbContext context;

        public CinemaController(CinemaDbContext dbContext)
        {
            context = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await context.Cinemas
                .Select(c => new CinemaIndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location
                })
                .OrderBy(c => c.Name)
                .ToListAsync();

            return View(cinemas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            Cinema cinema = new Cinema()
            {
                Name = inputModel.Name,
                Location = inputModel.Location
            };

            await context.Cinemas.AddAsync(cinema);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid cinemaGuid = Guid.Empty;
            bool IsIdValid = IsGuidValid(id, ref cinemaGuid);
            if (!IsIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Cinema? cinema = await context.Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefaultAsync(c => c.Id.ToString() == id);

            if (cinema == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel()
            {
                Id = cinema.Id.ToString(),
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies
                    .Select(cm => new MovieProgramViewModel()
                    {
                        Title = cm.Movie.Title,
                        Duration = cm.Movie.Duration
                    })
                    .ToList()
            };

            return View(cinemaDetailsViewModel);
        }
    }
}
