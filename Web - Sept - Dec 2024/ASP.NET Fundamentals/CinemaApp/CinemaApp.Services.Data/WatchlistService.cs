using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Identity;
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
		private readonly IRepository<ApplicationUserMovie, object> userMovieRepository;
		private readonly IRepository<Movie, Guid> movieRepository;

        public WatchlistService(IRepository<ApplicationUserMovie, object> userMovieRepository, IRepository<Movie, Guid> movieRepository)
        {
            this.userMovieRepository = userMovieRepository;
			this.movieRepository = movieRepository;
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
			Guid movieGuid = Guid.Empty;
			bool isMovieGuidValid = IsGuidValid(movieId, ref movieGuid);
			if (!isMovieGuidValid)
			{
				return false;
			}

			Movie? movie = await this.movieRepository
				.GetByIdAsync(movieGuid);
			if (movie == null)
			{
				return false;
			}

			if (String.IsNullOrWhiteSpace(userId))
			{
				// This case is probably never going to be hit, just in case, defensive programming against exceptions
				return false;
			}

			Guid userGuid = Guid.Parse(userId);
			ApplicationUserMovie? addedToWatchlistAlready = await this.userMovieRepository
				.FirstOrDefaultAsync(um => um.MovieId == movieGuid && um.ApplicationUserId == userGuid);

			if (addedToWatchlistAlready == null)
			{
				ApplicationUserMovie newUserMovie = new ApplicationUserMovie()
				{
					ApplicationUserId = userGuid,
					MovieId = movieGuid
				};

				await this.userMovieRepository.AddAsync(newUserMovie);
			}

			return true;
		}

		public async Task<bool> RemoveMovieFromUserWatchlistAsync(string? movieId, string userId)
		{
            Guid movieGuid = Guid.Empty;
            if (!IsGuidValid(movieId, ref movieGuid))
            {
				return false;
            }

			Movie? movie = await this.movieRepository.GetByIdAsync(movieGuid);
			if (movie == null)
			{
				return false;
			}

            Guid userGuid = Guid.Parse(userId);

            ApplicationUserMovie? userMovieToRemove = await this.userMovieRepository
                .FirstOrDefaultAsync(um => um.MovieId == movieGuid && um.ApplicationUserId == userGuid);

            if (userMovieToRemove != null)
            {
                await userMovieRepository.DeleteAsync(userMovieToRemove!);
            }

			return true;
        }
	}
}
