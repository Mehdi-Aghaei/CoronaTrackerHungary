using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;

namespace CoronaTrackerHungary.Web.Api.Brokers.APIs
{
    public partial interface IApiBroker
    {
        ValueTask<List<Country>> GetAllCountriesAsync();
    }
}
