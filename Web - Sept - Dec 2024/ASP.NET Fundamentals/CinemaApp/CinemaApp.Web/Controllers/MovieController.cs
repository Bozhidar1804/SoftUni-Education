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
using Microsoft.AspNetCore.Authorization;
using CinemaApp.Web.Infrastructure.Extensions;


namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService, IManagerService managerService)
            : base(managerService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AllMoviesIndexViewModel> allMovies = await movieService.IndexGetAllMoviesAsync();

            return View(allMovies);
        }

        [HttpGet]
        [Authorize]
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
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
        {
            bool isManager = await this.IsUserManagerAsync();

            if (!isManager)
            {
                return RedirectToAction(nameof(Index));
            }

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
        [Authorize]
        public async Task<IActionResult> AddToProgram(string? movieId)
        {
            bool isManager = await this.IsUserManagerAsync();

            if (!isManager)
            {
                return RedirectToAction(nameof(Index));
            }

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
        [Authorize]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaProgramInputModel model)
        {
            bool isManager = await this.IsUserManagerAsync();

            if (!isManager)
            {
                return RedirectToAction(nameof(Index));
            }

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

            bool addingResult = await this.movieService.AddMovieToCinemas(model, movieGuid);
            if (addingResult == false)
            {
                return this.RedirectToAction(nameof(Index));
            }
         
            return RedirectToAction(nameof(Index), "Cinema");
        }
    }
}
