using Newtonsoft.Json.Linq;
using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace Renttracker.UWP.Controllers
{
    public static class ProtoController
    {
        public static async Task<IEnumerable<Home>> GetHomesFromSampleJsonAsync()
        {
            var homes = new List<Home>();
            var homesFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///homes.json"));
            var homesJson = await FileIO.ReadTextAsync(homesFile);
            homes = JArray.Parse(homesJson).ToObject<List<Home>>();
            return homes;
        }
    }
}
