using Newtonsoft.Json.Linq;
using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Renttracker.Services.DataServices
{
    public class DataService : IDataService
    {
        private DataService()
        {

        }
        private static DataService _current = new DataService();
        public static DataService Current
        {
            get
            {
                return _current;
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
