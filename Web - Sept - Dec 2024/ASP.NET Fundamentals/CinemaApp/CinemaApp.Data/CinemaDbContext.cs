using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data
{
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
            
        }

        public CinemaDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Cinema> Cinemas { get; set; }

        public virtual DbSet<CinemaMovie> CinemasMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
