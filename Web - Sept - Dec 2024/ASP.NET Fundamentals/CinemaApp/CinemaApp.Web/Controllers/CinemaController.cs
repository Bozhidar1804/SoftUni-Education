
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Data;
using CinemaApp.Web.ViewModels.Cinema;

namespace CinemaApp.Web.Controllers
{
	public class CinemaController : BaseController
	{
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await this.cinemaService
                .IndexGetAllOrderedByNameAsync();

            return View(cinemas);
        }

        [HttpGet]
        public IActionResult Create()
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

            await cinemaService.AddCinemaAsync(inputModel);

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

            CinemaDetailsViewModel cinemaDetailsViewModel =  await cinemaService.GetCinemaDetailsByIdAsync(cinemaGuid);

            if (cinemaDetailsViewModel == null)
            {
                RedirectToAction(nameof(Index));
            }

            return View(cinemaDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await this.cinemaService.IndexGetAllOrderedByNameAsync();
            return this.View(cinemas);
        }
    }
}
