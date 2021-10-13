using CoronaTrackerHungary.Web.Api.Models.Countries;

namespace CoronaTrackerHungary.Web.Api.Brokers.API
{
    public partial class ApiBroker
    {
        private string RelativeUrl = "v2/countries";

        public async ValueTask<List<Country>> GetAllCountriesAsync()
        {
            return await this.GetAsync<List<Country>>(RelativeUrl);

        }

    }
}
