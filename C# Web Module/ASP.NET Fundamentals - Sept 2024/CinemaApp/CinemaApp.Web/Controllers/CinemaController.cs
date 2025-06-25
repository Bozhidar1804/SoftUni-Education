
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Data;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using CinemaApp.Web.Infrastructure.Extensions;

namespace CinemaApp.Web.Controllers
{
	public class CinemaController : BaseController
	{
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService, IManagerService managerService)
            : base(managerService)
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
        public async Task<IActionResult> Create()
        {
            bool isManager = await this.IsUserManagerAsync();

            if (!isManager)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CinemaCreateViewModel inputModel)
        {
            bool isManager = await this.IsUserManagerAsync();

            if (!isManager)
            {
                return RedirectToAction(nameof(Index));
            }

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
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            bool isManager = await this.IsUserManagerAsync();

            if (!isManager)
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<CinemaIndexViewModel> cinemas = await this.cinemaService.IndexGetAllOrderedByNameAsync();
            return this.View(cinemas);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            bool isManager = await this.IsUserManagerAsync();

            if (!isManager)
            {
                //TODO: Implement notifications for warning and error messages!
                return RedirectToAction(nameof(Index));
            }

            Guid cinemaGuid = Guid.Empty;
            bool IsIdValid = IsGuidValid(id, ref cinemaGuid);
            if (!IsIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            EditCinemaFormModel? cinemaFormModel = await cinemaService.GetCinemaToEditByIdAsync(cinemaGuid);

            return this.View(cinemaFormModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditCinemaFormModel cinemaFormModel, string Id)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                //TODO: Implement notifications for warning and error messages!
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                return View(cinemaFormModel);
            }

            Guid cinemaGuid = Guid.Empty;
            bool IsIdValid = IsGuidValid(Id, ref cinemaGuid);
            if (!IsIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            bool IsAdded = await this.cinemaService.EditCinemaAsync(cinemaFormModel, cinemaGuid);

            if (!IsAdded)
            {
                ModelState.AddModelError(string.Empty, "Invalid validation");
                return this.View(cinemaFormModel);
            }

            return RedirectToAction(nameof(Details), "Cinema", new { id = cinemaFormModel.Id });
        }
    }
}
