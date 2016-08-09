using Renttracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker
{
    public sealed class CoreApp
    {
        private CoreApp(ILocationService locationService)
        {
            LocationService = locationService;
            
        }

        public static void Initialize(ILocationService locationService)
        {
            if (IsInitialized)
                return;

            _current = new CoreApp(locationService);
            IsInitialized = true;
        }

        private static bool IsInitialized { get; set; }

        private static CoreApp _current;
        public static CoreApp Current
        {
            get
            {
                if (!IsInitialized)
                    throw new InvalidOperationException("CoreApp is currently uninitialized.");

                return _current;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Current cannot be null");

                _current = value;
            }
        }

        private ILocationService _locationService = default(ILocationService);
        public ILocationService LocationService
        {
            get
            {
                return _locationService;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "ILocationService instance cannot be null");
                _locationService = value;
            }
        }
      
    }
}
