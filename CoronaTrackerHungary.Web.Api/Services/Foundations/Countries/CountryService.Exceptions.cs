using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions;

namespace CoronaTrackerHungary.Web.Api.Services.Foundations.Countries
{
    public partial class CountryService
    {
        private delegate ValueTask<List<Country>> ReturningCountriesFunction();

        private async ValueTask<List<Country>> TryCatch(ReturningCountriesFunction returningCountriesFunction)
        {
            try
            {
                return await returningCountriesFunction();
            }
            catch (Exception exception)
            {
                var failedCountryServiceException =
                    new FailedCountryServiceException(exception);

                throw CreateAndLogServiceException(failedCountryServiceException);
            }
        }

        private CountryServiceException CreateAndLogServiceException(Exception exception)
        {
            var countryServiceException = 
                new CountryServiceException(exception);
            this.loggingBroker.LogError(countryServiceException);

            return countryServiceException;
        }

    }
}
