using CoronaTrackerHungary.Web.Api.Models.Countries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaTrackerHungary.Web.Api.Brokers.API
{
    public partial interface IApiBroker
    {
        ValueTask<List<Country>> GetAllCountriesAsync();

    }
}
