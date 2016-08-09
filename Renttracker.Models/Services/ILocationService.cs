﻿using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services
{
    public interface ILocationService
    {
        /// <summary>
        /// Gets house data from a JSON sample file.
        /// </summary>
        /// <returns>IEnumerable (Home - asynchronous)</returns>
        Task<IEnumerable<Home>> GetHomesFromSampleAsync();

        /// <summary>
        /// Gets house data from the Internet
        /// </summary>
        /// <returns>IEnumerable (Home - asynchronous)</returns>
        Task<IEnumerable<Home>> GetHomesAsync();
    }
}
