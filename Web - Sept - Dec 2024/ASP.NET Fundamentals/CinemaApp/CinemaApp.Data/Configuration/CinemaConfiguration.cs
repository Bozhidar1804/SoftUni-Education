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
	using static Common.EntityValidationConstants.Cinema;
	public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
	{
		public void Configure(EntityTypeBuilder<Cinema> builder)
		{
			builder.HasKey(c => c.Id);

			builder
				.Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(NameMaxLength);

			builder
				.Property(c => c.Location)
				.IsRequired()
				.HasMaxLength(LocationMaxLength);

			builder.HasData(this.GenerateCinemas());
		}

		private IEnumerable<Cinema> GenerateCinemas()
		{
			IEnumerable<Cinema> cinemas = new List<Cinema>()
			{
				new Cinema()
				{
					Name = "Cinema City",
					Location = "Sofia"
				},
				new Cinema()
				{
					Name = "Cinema City",
					Location = "Plovdiv"
				},
				new Cinema()
				{
					Name = "Cinemax",
					Location = "Varna"
				}
			};

			return cinemas;
		}
	}
}
