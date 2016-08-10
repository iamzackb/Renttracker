using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renttracker.Models;

namespace Renttracker.Services.DataServices
{
    public sealed class DataService : DataServiceBase
    {
        private DataService()
        {
            _current = this;
        }

        private static DataService _current = new DataService();
        public static DataService Current
        {
            get
            {
                if (_current == null)
                    _current = new DataService();
                return _current;
            }
        }

        public override async Task<IEnumerable<Home>> GetHomesAsync()
        {
#warning DataService.GetHomesAsync() just returns the result of ProtoDataService.GetHomesAsync().
            // TODO: Implement GetHomesAsync()
            return (await ProtoDataService.Current.GetHomesAsync());
        }
    }
}
