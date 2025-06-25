using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configuration
{
    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> builder)
        {
            builder
                .HasKey(um => new { um.ApplicationUserId, um.MovieId });

            builder
                .HasOne(um => um.Movie)
                .WithMany(m => m.MovieApplicationUsers)
                .HasForeignKey(um => um.MovieId);

            builder
                .HasOne(um => um.ApplicationUser)
                .WithMany(au => au.ApplicationUserMovies)
                .HasForeignKey(um => um.ApplicationUserId);
        }
    }
}
