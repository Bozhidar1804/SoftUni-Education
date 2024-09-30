using CinemaApp.Data;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = context.Cinemas
                .Select(c => new CinemaIndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location
                })
                .ToList();

            return View(cinemas);
        }
	}
}
