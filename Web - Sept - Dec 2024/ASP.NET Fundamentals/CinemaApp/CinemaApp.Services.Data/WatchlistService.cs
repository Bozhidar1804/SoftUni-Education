using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Services.Data
{
	public class WatchlistService : BaseService, IWatchlistService
	{
		private readonly IRepository<ApplicationUserMovie, object[]> userMovieRepository;

        public WatchlistService(IRepository<ApplicationUserMovie, object[]> userMovieRepository)
        {
            this.userMovieRepository = userMovieRepository;
        }

		public async Task<IEnumerable<ApplicationUserWatchlistViewModel>> GetUserWatchlistByIdAsync(string userId)
		{
			IEnumerable<ApplicationUserWatchlistViewModel> watchlist = await this.userMovieRepository
				.GetAllAttached()
				.Include(um => um.Movie)
				.Where(um => um.ApplicationUserId.ToString().ToLower() == userId.ToLower())
				.Select(um => new ApplicationUserWatchlistViewModel()
				{
					MovieId = um.MovieId.ToString(),
					Title = um.Movie.Title,
					Genre = um.Movie.Genre,
					ReleaseDate = um.Movie.ReleaseDate.ToString(ReleaseDateFormat),
					ImageUrl = um.Movie.ImageUrl
				})
				.ToListAsync();

			return watchlist;
		}

		public async Task<bool> AddMovieToUserWatchlistAsync(string? movieId, string userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveMovieFromUserWatchlistAsync(string? movieId, string userId)
		{
			throw new NotImplementedException();
		}
	}
}
