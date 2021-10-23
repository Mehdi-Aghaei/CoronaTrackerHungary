using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions;
using Microsoft.Data.SqlClient;

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
            catch(SqlException sqlException) 
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
            catch (Exception exception)
            {
                var failedCountryServiceException =
                    new FailedCountryServiceException(exception);

                throw CreateAndLogServiceException(failedCountryServiceException);
            }
        }
        private CountryDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var countryDependencyException = 
                new CountryDependencyException(exception);
            this.loggingBroker.LogCritical(countryDependencyException);

            return countryDependencyException;
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
