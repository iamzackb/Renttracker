using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Renttracker.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class HomeLocation : ModelBase
    {
       




        public override string Name
        {
            get
            {
                return ToString();
            }
        }

        
        /// <summary>
        /// Represents the address of a home
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; private set; }

        /// <summary>
        /// Represents the suburb in which a home is located
        /// </summary>
        [JsonProperty("suburb")]
        public string Suburb { get; private set; }

        /// <summary>
        /// Represents the city in which a home is located
        /// </summary>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>
        /// Represents the region in which a home is located
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; private set; }

        /// <summary>
        /// Represents the country in which a home is located
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; private set; }

        /// <summary>
        /// Represents the post code associated with a particular home
        /// </summary>
        [JsonProperty("postCode")]
        public string PostCode { get; private set; }

        /// <summary>
        /// Latitude in which a home is located
        /// </summary>
        [JsonProperty("latitude")]
        public double? Latitude { get; private set; }

        /// <summary>
        /// Longitude in which a home is located
        /// </summary>
        [JsonProperty("longitude")]
        public double? Longitude { get; private set; }

        public override string ToString()
        {
            return $"{Address}, {Suburb}, {City} {PostCode}, {Region}, {Country}";
        }



    }
}
