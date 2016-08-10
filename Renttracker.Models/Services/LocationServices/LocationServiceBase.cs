using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services.LocationServices
{
    public abstract class LocationServiceBase : ILocationService
    {
        public abstract event EventHandler<LocationAvailabilityChangedEventArgs> LocationAvailabilityChanged;

        public abstract Task RequestLocationAccess();
    }
}
