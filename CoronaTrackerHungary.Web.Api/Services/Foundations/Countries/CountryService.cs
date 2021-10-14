using CoronaTrackerHungary.Web.Api.Brokers.API;
using CoronaTrackerHungary.Web.Api.Brokers.Logging;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaTrackerHungary.Web.Api.Services.Foundations.Countries
{
    public class CountryService : ICountryService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;
        public CountryService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }
        public ValueTask<List<Country>> RetrieveAllCountrieasAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
