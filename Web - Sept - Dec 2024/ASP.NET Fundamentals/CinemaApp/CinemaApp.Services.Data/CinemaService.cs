using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels.Movie;


namespace CinemaApp.Services.Data
{
    public class CinemaService : BaseService, ICinemaService
    {
        private readonly IRepository<Cinema, Guid> cinemaRepository;

        public CinemaService(IRepository<Cinema, Guid> cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }


        public async Task<IEnumerable<CinemaIndexViewModel>> IndexGetAllOrderedByNameAsync()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await this.cinemaRepository
                .GetAllAttached()
                .OrderBy(c => c.Name)
                .To<CinemaIndexViewModel>()
                .ToListAsync();

            return cinemas;
        }
        public async Task AddCinemaAsync(CinemaCreateViewModel inputModel)
        {
            Cinema cinema = new Cinema();
            AutoMapperConfig.MapperInstance.Map(inputModel, cinema);

            await cinemaRepository.AddAsync(cinema);
        }

        public async Task<CinemaDetailsViewModel> GetCinemaDetailsByIdAsync(Guid id)
        {
            Cinema? cinema = await cinemaRepository
                .GetAllAttached()
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);

            CinemaDetailsViewModel cinemaDetailsViewModel = null!;
            if (cinema != null)
            {
                cinemaDetailsViewModel = new CinemaDetailsViewModel()
                {
                    Id = cinema.Id.ToString(),
                    Name = cinema.Name,
                    Location = cinema.Location,
                    Movies = cinema.CinemaMovies
                    .Select(cm => new MovieProgramViewModel()
                    {
                        Title = cm.Movie.Title,
                        Duration = cm.Movie.Duration
                    })
                    .ToList()
                };
            }

            return cinemaDetailsViewModel;
        }

        public async Task<EditCinemaFormModel?> GetCinemaToEditByIdAsync(Guid id)
        {
            EditCinemaFormModel? cinemaModel = await cinemaRepository
                .GetAllAttached()
                .Select(c => new EditCinemaFormModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location
                })
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());
                
            return cinemaModel;
        }
    }
}
