using Renttracker.Models;
using Renttracker.Services;
using Renttracker.Services.LocationServices;
using Renttracker.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;

namespace Renttracker.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        public MapPageViewModel()
        {
            LocationService.Current.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "IsLocationAvailable")
                    IsLocationAvailable = LocationService.Current.IsLocationAvailable;
            };
        }

        public async void RequestLocationAccessAsync(object sender, RoutedEventArgs args)
        {
            await LocationService.Current.RequestLocationAccess();
        }

        Home _location;

        private bool _isLocationAvailable;
        public bool IsLocationAvailable
        {
            get
            {
                return _isLocationAvailable;
            }
            private set
            {
                Set(ref _isLocationAvailable, value);
            }
        }


        public Home Location { get { return _location; } set { Set(ref _location, value); } }

        public MapControl MainMapControl;

        public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Location = SessionState["map_location"] as Home;
            MainMapControl = (NavigationService.Content as MapPage).FindName("MainMapControl") as MapControl;       //Pull our MainMapControl from the XAML.

            if (!Location.HasValidAddress())
            {
                if (!Location.HasValidCoordinates())
                    throw new InvalidOperationException("Selected location has invalid criteria");

                var latitude = Location.Location.Latitude.Value;
                var longitude = Location.Location.Longitude.Value;
                SetMapPointFromCoordinates(latitude, longitude);
            }

            else
            {
                //Assume it's an address

                #region Get access to current location
                var accessStatus = await Geolocator.RequestAccessAsync();
                var geolocator = new Geolocator();
                var pos = await geolocator.GetGeopositionAsync();
                #endregion Get access to current location

                #region Search addresses
                //When searching, it will favor addresses near this location
                var queryHint = new BasicGeoposition
                {
                    Latitude = pos.Coordinate.Point.Position.Latitude,
                    Longitude = pos.Coordinate.Point.Position.Longitude
                };

                var hintPoint = new Geopoint(queryHint);
                var result = await MapLocationFinder.FindLocationsAsync(Location.Name, hintPoint);
                #endregion Search addresses

                if (result.Status == MapLocationFinderStatus.Success && result.Locations.Count > 0)
                    SetMapPointFromCoordinates(result.Locations[0].Point.Position.Latitude, result.Locations[0].Point.Position.Longitude);
            }

            await Task.CompletedTask;
        }

        void SetMapPointFromCoordinates(double latitude, double longitude)
        {
            var mapPoint = new Geopoint(new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            });

            var mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Marker Filled-60.png"));
            var pin = new MapIcon
            {
                Location = mapPoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Image = mapIconStreamReference
            };

            MainMapControl.MapElements.Add(pin);
            MainMapControl.Center = mapPoint;
        }
    }
}
