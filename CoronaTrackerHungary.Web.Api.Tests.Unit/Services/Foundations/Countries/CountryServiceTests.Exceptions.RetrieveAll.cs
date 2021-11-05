using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions;
using Moq;
using RESTFulSense.Exceptions;
using Xunit;

namespace CoronaTrackerHungary.Web.Api.Tests.Unit.Services.Foundations.Countries
{
    public partial class CountryServiceTests
    {
        [Theory]
        [MemberData(nameof(CriticalDependencyException))]
        public async Task ShouldThrowCriticalDependencyExceptionOnRetrieveAllIfCriticalDependencyExceptionOccursAndLogItAsync(
            Exception criticalDependencyException)
        {
            // given
            var failedCountryDependencyException =
                new FailedCountryDependencyException(
                    criticalDependencyException);

            var expectedCountryDependencyException =
                new CountryDependencyException(
                    failedCountryDependencyException);

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllCountriesAsync())
                .ThrowsAsync(criticalDependencyException);

            // when
            ValueTask<List<Country>> retrieveAllCountriesTask =
                this.countryService.RetrieveAllCountrieasAsync();

            // then
            await Assert.ThrowsAsync<CountryDependencyException>(() =>
                retrieveAllCountriesTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllCountriesAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedCountryDependencyException))),
                        Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyApiException))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveAllIfDependencyApiErrorOccursAndLogItAsync(
            Exception dependencyApiException)
        {
            // given 
            var failedCountryDependencyException =
                new FailedCountryDependencyException(dependencyApiException);

            var expectedCountryDependencyException =
                new CountryDependencyException(failedCountryDependencyException);

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllCountriesAsync())
                .ThrowsAsync(dependencyApiException);

            // when
            ValueTask<List<Country>> retrieveAllCountriesTask =
                this.countryService.RetrieveAllCountrieasAsync();

            // then
            await Assert.ThrowsAsync<CountryDependencyException>(() =>
                retrieveAllCountriesTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllCountriesAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedCountryDependencyException))),
                        Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogItAsync()
        {
            // given
            var serviceException = new Exception();

            var failedCountryException =
                new FailedCountryServiceException(serviceException);

            var expectedCountryServiceException =
                new CountryServiceException(failedCountryException);

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllCountriesAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<List<Country>> getAllCountriesTask =
                this.countryService.RetrieveAllCountrieasAsync();

            // then
            await Assert.ThrowsAsync<CountryServiceException>(() =>
                getAllCountriesTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllCountriesAsync(),
                    Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                expectedCountryServiceException))),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
