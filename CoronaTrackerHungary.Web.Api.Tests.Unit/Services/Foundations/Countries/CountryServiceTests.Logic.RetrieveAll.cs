using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace CoronaTrackerHungary.Web.Api.Tests.Unit.Services.Foundations.Countries
{
    public partial class CountryServiceTests
    {
        [Fact]
        public async ValueTask ShouldRetrieveAllCountriesAndLogItAsync()
        {
            // given
            List<Country> randomCountries = CreateRandomCountries();
            List<Country> apiCountries = randomCountries;
            List<Country> expectedCountries = apiCountries.DeepClone();

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllCountriesAsync())
                    .ReturnsAsync(apiCountries);
            // when
            List<Country> retrievedCountries =
                await this.countryService.RetrieveAllCountrieasAsync();

            // then
            retrievedCountries.Should().BeEquivalentTo(expectedCountries);

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllCountriesAsync(),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();

        }

    }
}
