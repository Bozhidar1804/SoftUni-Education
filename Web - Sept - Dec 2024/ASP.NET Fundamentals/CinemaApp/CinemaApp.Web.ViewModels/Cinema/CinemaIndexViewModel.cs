using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Cinema
{
    using CinemaApp.Services.Mapping;
    using CinemaApp.Data.Models;

    public class CinemaIndexViewModel : IMapFrom<Cinema>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
