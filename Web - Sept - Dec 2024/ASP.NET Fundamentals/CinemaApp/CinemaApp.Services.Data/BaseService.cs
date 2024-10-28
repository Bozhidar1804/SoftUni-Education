using CinemaApp.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Data
{
	public class BaseService : IBaseService
	{
		public bool IsGuidValid(string? id, ref Guid parsedGuid)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				return false;
			}

			bool isGuidValid = Guid.TryParse(id, out parsedGuid);
			if (!isGuidValid)
			{
				return false;
			}

			return true;
		}
	}
}
