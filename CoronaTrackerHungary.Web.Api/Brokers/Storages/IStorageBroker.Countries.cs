using System.Linq;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;

namespace CoronaTrackerHungary.Web.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Country> InsertCountryAsync(Country country);
        IQueryable<Country> SelectAllCountries();
        ValueTask<Country> UpdateCountryAsync(Country country);
    }
}
