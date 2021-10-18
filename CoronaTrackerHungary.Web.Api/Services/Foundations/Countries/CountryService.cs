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
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;
        public CountryService(IApiBroker apiBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
        {
            this.dateTimeBroker = dateTimeBroker;
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }
        public ValueTask<List<Country>> RetrieveAllCountrieasAsync() =>
           TryCatch(async () =>
           {
                List<Country> allCountries =  await this.apiBroker.GetAllCountriesAsync();

               return allCountries;
           });          
    }
}
