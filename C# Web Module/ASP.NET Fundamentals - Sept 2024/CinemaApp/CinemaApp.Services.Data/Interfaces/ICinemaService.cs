using CinemaApp.Data.Migrations;
using CinemaApp.Web.ViewModels.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<CinemaIndexViewModel>> IndexGetAllOrderedByNameAsync();

        Task AddCinemaAsync(CinemaCreateViewModel inputModel);

        Task<CinemaDetailsViewModel> GetCinemaDetailsByIdAsync(Guid id);

        Task<EditCinemaFormModel> GetCinemaToEditByIdAsync(Guid id);

        Task<bool> EditCinemaAsync(EditCinemaFormModel inputModel, Guid Id);
    }
}
