using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Country : IFormattable
    {
        [JsonProperty("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("countryCode")]
        public string CountryCode
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{ Name } ({ CountryCode })";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
           switch (format)
            {
                case "CC":
                    return CountryCode;
                case "CN":
                    return Name;
                default:
                    return ToString();
            }
        }

        public static bool operator ==(Country lhs, Country rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return true;

            if (((object)lhs == null) || ((object)rhs == null))
                return false;

            return lhs.Name == rhs.Name && lhs.CountryCode == rhs.CountryCode;
        }

        public static bool operator !=(Country lhs, Country rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Country country = obj as Country;

            if (country == null)
                return false;

            return (country.Name == this.Name && country.CountryCode == this.CountryCode);
        }

        public bool Equals(Country country)
        {
            return country == this;
        }

        public override int GetHashCode()
        {
             return CountryCode.GetHashCode() + Name.GetHashCode();
        }
    }
}
