using Homies.Data;
using Homies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;
using System.Globalization;
using static Homies.ApplicationConstants.EntityValidationConstants.Event;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public EventController(HomiesDbContext _dbContext, UserManager<IdentityUser> _userManager)
        {
            this.dbContext = _dbContext;
            this.userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<EventInfoViewModel> events = await dbContext
                .Events
                .Select(e => new EventInfoViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(EventStartFormat),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventAddInputModel model = new EventAddInputModel();
            model.Types = await dbContext.Types.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventAddInputModel model)
        {
            string userId = this.userManager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid validation");

                model.Types = await dbContext.Types.ToListAsync();
                return View(model);
            }

            DateTime startDate;
            bool IsStartDateValid = DateTime.TryParseExact(model.Start, EventStartFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

            if (!IsStartDateValid)
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid start date! Format should be: {EventStartFormat}");
            }

            DateTime endDate;
            bool IsEndDateValid = DateTime.TryParseExact(model.End, EventEndFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!IsEndDateValid)
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid end date! Format should be: {EventEndFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await dbContext.Types.ToListAsync();
                return View(model);
            }

            Event eventToAdd = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = userId,
                CreatedOn = DateTime.Now,
                Start = startDate,
                End = endDate,
                TypeId = model.TypeId,
            };

            await dbContext.Events.AddAsync(eventToAdd);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
    }
}
