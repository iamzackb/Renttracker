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
    public sealed class LocationService : ILocationService, INotifyPropertyChanged
    {
        private LocationService()
        {
            _current = this;
        }


        private bool _isLocationAvailable;

        public bool IsLocationAvailable
        {
            get
            {
                return _isLocationAvailable;
            }
            private set
            {
                _isLocationAvailable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLocationAvailable)));
            }
        }

        private GeolocationAccessStatus _locatorStatus;
        private GeolocationAccessStatus LocatorStatus
        {
            get
            {
                return _locatorStatus;
            }
            set
            {
                _locatorStatus = value;
                IsLocationAvailable = (value == GeolocationAccessStatus.Allowed);
            }
        }

        public async Task RequestLocationPermissions()
        {
            LocatorStatus = await Geolocator.RequestAccessAsync();
            await Task.CompletedTask;
        }
       

        private static LocationService _current = new LocationService();

        public event PropertyChangedEventHandler PropertyChanged;

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
            var homes = new List<Home>();
            var homesFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///homes.json"));
            var homesJson = await FileIO.ReadTextAsync(homesFile);
            homes = JArray.Parse(homesJson).ToObject<List<Home>>();
            return homes;
        }
    }
}
