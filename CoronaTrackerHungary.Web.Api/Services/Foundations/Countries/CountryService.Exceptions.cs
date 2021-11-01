using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions;
using RESTFulSense.Exceptions;

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
            catch(HttpRequestException httpRequestException)
            {
                var failedCountryDependencyException =
                    new FailedCountryDependencyException(httpRequestException);

               throw CreateAndLogCriticalDependencyException(failedCountryDependencyException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedCountryDependencyException =
                    new FailedCountryDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedCountryDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException )
            {
                var failedCountryDependencyExcpetion = 
                    new FailedCountryDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedCountryDependencyExcpetion);
            }
            catch (Exception serviceException)
            {
                var failedCountryServiceException =
                    new FailedCountryServiceException(serviceException);

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
