using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;

namespace CoronaTrackerHungary.Web.Api.Brokers.API
{
    public partial class ApiBroker
    {
        private const string relativeUrl = "v2/countries";

        public async ValueTask<List<Country>> GetAllCountriesAsync() =>
            await this.GetAsync<List<Country>>(relativeUrl);
    }
}
