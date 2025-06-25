using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Web.ViewModels.Movie;
using CinemaApp.Web.ViewModels.Watchlist;

namespace CinemaApp.Services.Data.Interfaces
{
	public interface IWatchlistService
	{
		Task<IEnumerable<ApplicationUserWatchlistViewModel>> GetUserWatchlistByIdAsync(string userId);

		Task<bool> AddMovieToUserWatchlistAsync(string? movieId, string userId);

		Task<bool> RemoveMovieFromUserWatchlistAsync(string? movieId, string userId);
	}
}
