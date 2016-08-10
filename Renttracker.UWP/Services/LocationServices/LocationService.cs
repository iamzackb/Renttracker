using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renttracker.Models;
using Windows.Storage;
using Newtonsoft.Json.Linq;
using Windows.Devices.Geolocation;
using System.ComponentModel;

namespace Renttracker.Services.LocationServices
{
    public sealed class LocationService : LocationServiceBase
    {

        public override event EventHandler<LocationAvailabilityChangedEventArgs> LocationAvailabilityChanged;


        private Geolocator _Locator = default(Geolocator);
        /// <summary>
        /// Represents a Geolocator object to be used in geolocation tasks.
        /// </summary>
        public Geolocator Locator
        {
            get
            {
                if (_Locator == null)
                {
                    _Locator = new Geolocator();
                    _Locator.StatusChanged += OnLocatorStatusChanged;
                }
                return _Locator;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Locator cannot be null");

                Locator = value;
            }
        }

        private void OnLocatorStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
           switch (args.Status)
            {
                case PositionStatus.Disabled:
                case PositionStatus.NotInitialized:
                case PositionStatus.NotAvailable:
                case PositionStatus.NoData:
                    OnLocatorAvailabilityChanged(LocationAccessStatus.Unavailable);
                    break;
                case PositionStatus.Initializing:
                    OnLocatorAvailabilityChanged(LocationAccessStatus.Initializing);
                    break;
                case PositionStatus.Ready:
                    OnLocatorAvailabilityChanged(LocationAccessStatus.Available);
                    break;
                default:
                    OnLocatorAvailabilityChanged(LocationAccessStatus.Unknown);
                    break;                    
            }
        }

        private void OnLocatorAvailabilityChanged(LocationAccessStatus locationStatus)
        {
            LocationAvailabilityChanged?.Invoke(this, new LocationAvailabilityChangedEventArgs(locationStatus));
        }

        public override async Task RequestLocationAccess()
        {
            await Geolocator.RequestAccessAsync();
            await Task.CompletedTask;
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

       
    }
}
