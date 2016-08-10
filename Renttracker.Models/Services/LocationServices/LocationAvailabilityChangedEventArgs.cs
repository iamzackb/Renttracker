using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services.LocationServices
{
    public enum LocationAccessStatus
    {
        Available = 1,
        Initializing = 2,
        Unavailable = 3,
        Unknown = 0

    }

    public sealed class LocationAvailabilityChangedEventArgs : EventArgs
    {
        public LocationAvailabilityChangedEventArgs(LocationAccessStatus status)
        {
            AccessStatus = status;
        }

        public LocationAccessStatus AccessStatus { get; }
    }
}
