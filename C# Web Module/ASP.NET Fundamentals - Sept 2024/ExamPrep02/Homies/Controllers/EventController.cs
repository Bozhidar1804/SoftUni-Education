using Homies.Data;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using static Homies.ApplicationConstants.EntityValidationConstants.Event;

namespace Homies.Controllers
{
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = this.userManager.GetUserId(User);

            List<EventInfoViewModel> joinedEventsOfUser = await dbContext
                .EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Include(ep => ep.Event)
                .Select(ep => new EventInfoViewModel()
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(EventStartFormat),
                    Type = ep.Event.Type.ToString(),
                    Organiser = ep.Event.Organiser.UserName
                })
                .ToListAsync();

            return View(joinedEventsOfUser);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int Id)
        {
            string userId = this.userManager.GetUserId(User);

            Event? eventToJoin = await dbContext
                .Events
                .Where(e => e.Id == Id)
                .FirstOrDefaultAsync();

            if (eventToJoin == null)
            {
                throw new ArgumentException("Invalid Event");
            }

            bool isEventAlreadyAddedToJoined = await dbContext.EventsParticipants.AnyAsync(ep => ep.EventId == Id
                                                                                              && ep.HelperId == userId);
            if (isEventAlreadyAddedToJoined)
            {
                return RedirectToAction(nameof(All));
            }


            eventToJoin.EventsParticipants.Add(new EventParticipant()
            {
                EventId = Id,
                HelperId = userId
            });
            
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            string userId = this.userManager.GetUserId(User);

            List<Data.Type> types = await dbContext.Types.ToListAsync(); 

            Event? eventToEdit = await dbContext
                .Events
                .Where(e => e.Id == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (eventToEdit == null)
            {
                throw new ArgumentException("Invalid event to edit.");
            }

            if (eventToEdit.OrganiserId != userId)
            {
                return Unauthorized();
            }

            EventEditFormModel modelFormToReturn = new EventEditFormModel()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start.ToString(EventStartFormat),
                End = eventToEdit.End.ToString(EventEndFormat),
                TypeId = eventToEdit.TypeId,
                Types = types
            };

            return View(modelFormToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventEditFormModel model, int Id)
        {
            string userId = this.userManager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid validation");

                model.Types = await dbContext.Types.ToListAsync();

                return View(model);
            }

            Event? eventToEdit = await dbContext.Events.Where(e => e.Id == Id).FirstOrDefaultAsync();

            if (eventToEdit == null)
            {
                throw new ArgumentException("Invalid event to edit.");
            }

            if (eventToEdit.OrganiserId != userId)
            {
                return Unauthorized();
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

            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.Start = startDate;
            eventToEdit.End = endDate;
            eventToEdit.TypeId = model.TypeId;

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            EventDetailsViewModel? eventToShowDetails = await dbContext
               .Events
               .Where(e => e.Id == Id)
               .Select(e => new EventDetailsViewModel()
               {
                   Id = e.Id,
                   Name = e.Name,
                   Description = e.Description,
                   Start = e.Start.ToString(EventStartFormat),
                   End = e.End.ToString(EventEndFormat),
                   CreatedOn = e.CreatedOn.ToString(EventCreatedOnFormat),
                   Organiser = e.Organiser.UserName,
                   Type = e.Type.Name
               })
               .FirstOrDefaultAsync();

            return View(eventToShowDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int Id)
        {
            string userId = this.userManager.GetUserId(User);

            Event? eventToLeave = await dbContext
                .Events
                .Where(e => e.Id == Id)
                .FirstOrDefaultAsync();

            if (eventToLeave == null)
            {
                return BadRequest();
            }

            EventParticipant? eventParticipantToRemove = await dbContext
                .EventsParticipants
                .Where(ep => ep.HelperId == userId && ep.EventId == Id)
                .FirstOrDefaultAsync();

            if (eventParticipantToRemove == null)
            {
                return BadRequest();
            }

            eventToLeave.EventsParticipants.Remove(eventParticipantToRemove);
            dbContext.EventsParticipants.Remove(eventParticipantToRemove);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
    }
}
