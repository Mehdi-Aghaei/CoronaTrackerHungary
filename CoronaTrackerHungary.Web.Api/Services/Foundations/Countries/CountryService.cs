using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Brokers.APIs;
using CoronaTrackerHungary.Web.Api.Brokers.Loggings;
using CoronaTrackerHungary.Web.Api.Models.Countries;

namespace CoronaTrackerHungary.Web.Api.Services.Foundations.Countries
{
    public partial class CountryService : ICountryService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;
        public CountryService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }
        public ValueTask<List<Country>> RetrieveAllCountrieasAsync() =>
        TryCatch(async () => await this.apiBroker.GetAllCountriesAsync());
    }
}



