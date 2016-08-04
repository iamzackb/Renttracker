using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renttracker.Models;
using Windows.Storage;
using Newtonsoft.Json.Linq;

namespace Renttracker.UWP.Controllers
{
    public static class CountryController
    {
        public static async Task<IEnumerable<Country>> GetCountriesFromJsonAsync()
        {
            var countries = new List<Country>();
            var countriesFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///countries.json"));
            var countriesJson = await FileIO.ReadTextAsync(countriesFile);
            countries = JArray.Parse(countriesJson).ToObject<List<Country>>();
            return countries;

        }
    }
}
