using CinemaApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.Infrastructure.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
		{
			using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
			CinemaDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<CinemaDbContext>();
			dbContext.Database.Migrate();

			return app;
		}
	}
}
