using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class HomeLocation : ModelBase
    {
        
       
        public override string Name
        {
            get
            {
                return $"{Address}, {Suburb}, {City}, {Region} {PostCode}";
            }
        }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
        
        [JsonProperty("suburb")]
        public string Suburb { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("postcode")]
        public uint PostCode { get; set; }
    }
}
