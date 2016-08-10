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
    public class ProtoDataService : IDataService
    {
        private ProtoDataService()
        {

        }

        public event DataSourceUpdatedEventHandler DataSourceUpdated;

        private static ProtoDataService _current = new ProtoDataService();
        public static ProtoDataService Current
        {
            get
            {
                return _current;
            }
            
        }
        public async Task<IEnumerable<Home>> GetHomesAsync()
        {
            var homes = new List<Home>();
            var homesFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///homes.json"));
            var homesJson = await FileIO.ReadTextAsync(homesFile);
            homes = JArray.Parse(homesJson).ToObject<List<Home>>();
            return homes;
        }

       
    }
}
