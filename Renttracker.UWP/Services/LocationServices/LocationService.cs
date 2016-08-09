using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renttracker.Models;

namespace Renttracker.Services.LocationServices
{
    public sealed class LocationService : ILocationService
    {
        private LocationService()
        {
            _current = this;
        }

        private static LocationService _current = new LocationService();
        public static LocationService Current
        {
            get
            {
                return _current;
            }
            private set
            {
                _current = value;
            }
        }

        public Task<IEnumerable<Home>> GetHomesAsync()
        {
            throw new NotImplementedException("GetHomesAsync() is yet to be implemented. Please recompile in Debug mode to use GetHomesFromSampleAsync(), and eliminate this error.");
        }

        public async Task<IEnumerable<Home>> GetHomesFromSampleAsync()
        {
            return (await Controllers.ProtoController.GetHomesFromSampleJsonAsync());
        }
    }
}
