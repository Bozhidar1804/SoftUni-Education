using CinemaApp.Data;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Models;

namespace CinemaApp.Web.Controllers
{
	public class CinemaController : Controller
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
	}
}
