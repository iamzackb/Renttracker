using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services.LocationServices
{
    public interface ILocationService
    {

        event EventHandler<LocationAvailabilityChangedEventArgs> LocationAvailabilityChanged;

        /// <summary>
        /// Requests access to the user's location
        /// </summary>
        /// <returns>Task (asynchronous)</returns>
        Task RequestLocationAccess();



       
    }
}
