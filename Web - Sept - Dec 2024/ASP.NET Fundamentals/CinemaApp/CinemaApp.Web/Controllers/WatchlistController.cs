using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchlistController : BaseController
    {
        private readonly CinemaDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistController(CinemaDbContext dbContext, UserManager<ApplicationUser> usermanager)
        {
            this.dbContext = dbContext;
            this.userManager = usermanager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = this.userManager.GetUserId(User)!;

            IEnumerable<ApplicationUserWatchlistViewModel> watchlist = await dbContext
                .UsersMovies
                .Include(um => um.Movie)
                .Where(um => um.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(um => new ApplicationUserWatchlistViewModel()
                {
                    MovieId = um.MovieId.ToString(),
                    Title = um.Movie.Title,
                    Genre = um.Movie.Genre,
                    ReleaseDate = um.Movie.ReleaseDate.ToString(ReleaseDateFormat),
                    ImageUrl = um.Movie.ImageUrl
                })
                .ToListAsync();


            return View(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string movieId)
        {
            Guid movieGuid = Guid.Empty;
            bool isMovieGuidValid = IsGuidValid(movieId, ref movieGuid);
            if (!isMovieGuidValid)
            {
                return RedirectToAction("Index", "Movie");
            }

            Movie? movie = await dbContext
                .Movies
                .FirstOrDefaultAsync(m => m.Id == movieGuid);
            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }

            Guid userGuid = Guid.Parse(this.userManager.GetUserId(User)!);
            bool addedToWatchlistAlready = await dbContext
                .UsersMovies
                .AnyAsync(um => um.ApplicationUserId == userGuid && um.MovieId == movieGuid);

            if (!addedToWatchlistAlready)
            {
                ApplicationUserMovie newUserMovie = new ApplicationUserMovie()
                {
                    ApplicationUserId = userGuid,
                    MovieId = movieGuid
                };

                await dbContext.UsersMovies.AddAsync(newUserMovie);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string movieId)
        {
            Guid movieGuid = Guid.Empty;
            if (!IsGuidValid(movieId, ref movieGuid))
            {
                return View(nameof(Index));
            }

            Guid userGuid = Guid.Parse(userManager.GetUserId(User)!);

            ApplicationUserMovie? userMovieToRemove = await dbContext
                .UsersMovies
                .FirstOrDefaultAsync(um => um.MovieId == movieGuid && um.ApplicationUserId == userGuid);

            if (userMovieToRemove != null)
            {
                dbContext.UsersMovies.Remove(userMovieToRemove!);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
