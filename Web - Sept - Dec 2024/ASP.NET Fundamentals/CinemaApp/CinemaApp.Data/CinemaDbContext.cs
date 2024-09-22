using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data
{
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
            
        }

        public CinemaDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; } 
    }
}
