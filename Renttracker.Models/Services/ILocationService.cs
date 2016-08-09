using Renttracker.Models;
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
        /// Verifies whether location data is available
        /// </summary>
        bool IsLocationAvailable { get; }

        Task RequestLocationAccess();



       
    }
}
