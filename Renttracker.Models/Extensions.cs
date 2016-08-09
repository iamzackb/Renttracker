using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renttracker.Models;


namespace Renttracker
{
    public static class Extensions
    {
        public static bool HasValidCoordinates(this Home home)
        {
            if (home.Location == null)
                return false;

            HomeLocation location = home.Location;

            if (location.Latitude == null || location.Longitude == null)
                return false;

            return true;
        }

        public static bool HasValidAddress(this Home home)
        {
            if (home.Location == null)
                return false;

            HomeLocation location = home.Location;

            if (string.IsNullOrEmpty(location.Address))
                return false;

            if (string.IsNullOrEmpty(location.City))
                return false;

            if (string.IsNullOrEmpty(location.PostCode))
                return false;

            if (string.IsNullOrEmpty(location.Region))
                return false;

            if (string.IsNullOrEmpty(location.Country))
                return false;

            return true;
        }
        public static string GetLocationString(this Home home)
        {
            if (home.Location == null)
                throw new ArgumentNullException(nameof(home.Location), "Location cannot be null");

            return home.Location.ToString();
        }

      

        public static double[] GetLocationCoordinates(this Home home)
        {
            if (home.Location == null)
                throw new ArgumentNullException(nameof(home.Location), "Location cannot be null");

            var location = home.Location;

            if (location.Latitude != null && location.Longitude != null)
            {
                return new double[] { (double)location.Latitude, (double)location.Longitude };                
            }
            else
            {
                throw new ArgumentNullException(nameof(location), "Location data was incomplete!");
            }
        }
    }
}
