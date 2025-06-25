using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
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
            var genres = await dbContext.Genres.ToListAsync();

            GameEditViewModel? game = await dbContext.Games
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .Select(g => new GameEditViewModel()
                {
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                    GenreId = g.GenreId,
                    Genres = genres
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameEditViewModel model, int id)
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

            Game? game = await dbContext.Games.FindAsync(id);

            if (game != null)
            {
                game.Title = model.Title;
                game.Description = model.Description;
                game.ImageUrl = model.ImageUrl;
                game.ReleasedOn = releasedOn;
                game.GenreId = model.GenreId;
                game.PublisherId = userId;

                await dbContext.SaveChangesAsync();
            } else
            {
                throw new ArgumentException("Invalid id!");
            }

            return RedirectToAction(nameof(All));
        }




        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            string userId = this.userManager.GetUserId(User);

            IEnumerable<GameInfoViewModel> gamesOfUser = await dbContext
                .GamersGames
                .Where(gg => gg.GamerId == userId)
                .Where(gg => gg.Game.IsDeleted == false)
                .Include(gg => gg.Game)
                .Select(gg => new GameInfoViewModel()
                {
                    Id = gg.Game.Id,
                    Title = gg.Game.Title,
                    Genre = gg.Game.Genre.ToString(),
                    ImageUrl = gg.Game.ImageUrl,
                    ReleasedOn = gg.Game.ReleasedOn.ToString(GameReleasedOnFormat),
                    Publisher = gg.Game.Publisher.UserName
                })
                .ToListAsync();

            return View(gamesOfUser);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int Id)
        {
            string userId = this.userManager.GetUserId(User);

            Game? game = await dbContext
                .Games
                .Where(g => g.Id == Id)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                throw new ArgumentException("Invalid Game");
            }

            bool isGameAlreadyAddedToZone = await dbContext.GamersGames.AnyAsync(gg => gg.GameId == Id);
            if (isGameAlreadyAddedToZone)
            {
                return RedirectToAction(nameof(All));
            }

            GamerGame ggToAdd = new GamerGame()
            {
                Game = game,
                GameId = game.Id,
                GamerId = userId,
            };

            await dbContext.GamersGames.AddAsync(ggToAdd);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int Id)
        {
            string userId = this.userManager.GetUserId(User);

            Game? gameToRemove = await dbContext
                .Games
                .Where(g => g.Id == Id)
                .FirstOrDefaultAsync();

            if (gameToRemove == null)
            {
                throw new ArgumentException("Invalid game");
            }

            GamerGame? entityToRemove = await dbContext
                .GamersGames
                .Where(gg => gg.GamerId == userId)
                .Where(gg => gg.GameId == gameToRemove.Id)
                .FirstOrDefaultAsync();

            if (entityToRemove == null)
            {
                throw new ArgumentException("Invalid pair of Gamer and Game");
            }

            dbContext.GamersGames.Remove(entityToRemove);
            await dbContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(MyZone));
        }


        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            GameDetailsViewModel? gameViewModel = await dbContext
                .Games
                .Where(g => g.Id == Id)
                .Where(g => g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    ImageUrl = g.ImageUrl,
                    Title = g.Title,
                    Description = g.Description,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();

            return View(gameViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            GameDeleteViewModel? gameDeleteViewModel = await dbContext
                .Games
                .Where(g => g.Id == Id)
                .Where(g => g.IsDeleted == false)
                .Select(g => new GameDeleteViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();


            return View(gameDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            Game? game = await dbContext
                .Games
                .Where(g => g.Id == Id)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (game != null)
            {
                game.IsDeleted = true;
            }

            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
