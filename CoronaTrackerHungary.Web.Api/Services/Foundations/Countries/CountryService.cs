using CoronaTrackerHungary.Web.Api.Brokers.API;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaTrackerHungary.Web.Api.Services.Foundations.Countries
{
    public class CountryService : ICountryService
    {
        private readonly IApiBroker apiBroker;
        public CountryService(IApiBroker apiBroker)
        {
            this.apiBroker = apiBroker;

        }
        public ValueTask<List<Country>> RetrieveAllCountrieasAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
