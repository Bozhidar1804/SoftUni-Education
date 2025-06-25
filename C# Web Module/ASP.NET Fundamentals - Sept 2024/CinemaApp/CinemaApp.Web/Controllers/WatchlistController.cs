using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Common.EntityValidationConstants.Movie;
using static CinemaApp.Common.ErrorMessages.Watchlist;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService watchlistService;
        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistController(UserManager<ApplicationUser> usermanager, IWatchlistService watchlistService, IManagerService managerService)
            : base(managerService)
        {
            this.userManager = usermanager;
            this.watchlistService = watchlistService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = this.userManager.GetUserId(User)!;

            if (String.IsNullOrWhiteSpace(userId))
            {
                return this.RedirectToPage("/Identity/Account/Login");
            }

            IEnumerable<ApplicationUserWatchlistViewModel> watchlist = await 
                this.watchlistService.GetUserWatchlistByIdAsync(userId);

            return View(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string movieId)
        {
            string userId = this.userManager.GetUserId(User)!;

            if (String.IsNullOrWhiteSpace(userId))
            {
				return this.RedirectToPage("/Identity/Account/Login");
			}

            bool result = await this.watchlistService.AddMovieToUserWatchlistAsync(movieId, userId);

            if (result == false)
            {
                TempData[nameof(AddToWatchlistNotSuccessfulMessage)] = AddToWatchlistNotSuccessfulMessage;
                return this.RedirectToAction("Index", "Movie");
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string movieId)
        {
            string userId = this.userManager.GetUserId(User)!;

            if (String.IsNullOrWhiteSpace(userId))
            {
                return this.RedirectToPage("/Identity/Account/Login");
            }

            bool result = await this.watchlistService.RemoveMovieFromUserWatchlistAsync(movieId, userId);

            if (result == false)
            {
                // TODO: Implement a way to transfer the Error Message to the View
                return this.RedirectToAction("Index", "Movie");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
