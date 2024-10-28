﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface IBaseService
    {
		bool IsGuidValid(string? id, ref Guid parsedGuid);

	}
}
