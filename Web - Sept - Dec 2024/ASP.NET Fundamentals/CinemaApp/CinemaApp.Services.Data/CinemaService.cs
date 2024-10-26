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


namespace CinemaApp.Services.Data
{
    public class CinemaService : ICinemaService
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
        public Task AddCinemaAsync(CinemaCreateViewModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task<CinemaDetailsViewModel> GetCinemaDetailsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
