using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(t => t.CinemaId)
                .IsRequired();

            builder
                .Property(t => t.MovieId)
                .IsRequired();

            builder
                .Property(t => t.UserId)
                .IsRequired();

            builder
                .HasOne(t => t.Cinema)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.CinemaId);

            builder
                .HasOne(t => t.Movie)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.MovieId);

            builder
                .HasOne(t => t.User)
                .WithMany (t => t.Tickets)
                .HasForeignKey(t => t.UserId);
        }
    }
}
