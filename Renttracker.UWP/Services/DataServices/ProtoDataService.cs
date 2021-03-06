﻿using Newtonsoft.Json.Linq;
using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Renttracker.Services.DataServices
{
    /// <summary>
    /// Prototype version of the Renttracker data service
    /// </summary>
    /// <remarks>
    /// This prototype retrieves the data from a sample JSON file.
    /// It is not intended to be used in the final product, and will be deprecated and removed prior to release.
    /// </remarks>
    public class ProtoDataService : DataServiceBase
    {
        private ProtoDataService()
        {

        }

       
        private static ProtoDataService _current = new ProtoDataService();
        public static ProtoDataService Current
        {
            get
            {
                return _current;
            }
            
        }


        public override async Task<IEnumerable<Home>> GetHomesAsync()
        {
            var homes = new List<Home>();
            var homesFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///homes.json"));
            var homesJson = await FileIO.ReadTextAsync(homesFile);
            homes = JArray.Parse(homesJson).ToObject<List<Home>>();
            return homes;
        }

       
    }
}
