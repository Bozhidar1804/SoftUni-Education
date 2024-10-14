using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static GameZone.ApplicationConstants.EntityValidationConstants.Game;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public GameController(GameZoneDbContext _dbContext, UserManager<IdentityUser> _userManager)
        {
            this.dbContext = _dbContext;
            this.userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var games = await dbContext.Games
                .Where(g => g.IsDeleted == false)
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    ImageUrl = g.ImageUrl,
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat)
                })
                .AsNoTracking()
                .ToListAsync();

            return View(games);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameAddInputModel();
            model.Genres = await dbContext.Genres.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameAddInputModel model)
        {
            string userId = this.userManager.GetUserId(User);

            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError(string.Empty, "Invalid validation");

                model.Genres = await dbContext.Genres.ToListAsync();

                return View(model);
            }

            DateTime releasedOn;
            bool isDateValid = DateTime.TryParseExact(model.ReleasedOn, GameReleasedOnFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out releasedOn);

            if (isDateValid == false)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid date format.");

                model.Genres = await dbContext.Genres.ToListAsync();

                return View(model);
            }

            Game game = new Game()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublisherId = userId,
                ReleasedOn = releasedOn,
                GenreId = model.GenreId,
            };

            await dbContext.Games.AddAsync(game);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            GameAddInputModel model = new GameAddInputModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameAddInputModel model)
        {
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            return View(new List<GameAddInputModel>());
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            return RedirectToAction(nameof(MyZone));
        }



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GameAddInputModel model)
        {
            return View();
        }
    }
}
