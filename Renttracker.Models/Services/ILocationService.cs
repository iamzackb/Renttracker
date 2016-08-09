using Renttracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Home>> GetHomesFromSampleAsync();
        Task<IEnumerable<Home>> GetHomesAsync();
    }
}
