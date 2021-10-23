using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Brokers.API;
using CoronaTrackerHungary.Web.Api.Brokers.DateTimes;
using CoronaTrackerHungary.Web.Api.Brokers.Logging;
using CoronaTrackerHungary.Web.Api.Models.Countries;

namespace CoronaTrackerHungary.Web.Api.Services.Foundations.Countries
{
    public partial class CountryService : ICountryService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        public CountryService(IApiBroker apiBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }
        public ValueTask<List<Country>> RetrieveAllCountrieasAsync() =>
           TryCatch(async () =>
           {
               List<Country> allCountries = await this.apiBroker.GetAllCountriesAsync();

               return allCountries;
           });
    }
}
