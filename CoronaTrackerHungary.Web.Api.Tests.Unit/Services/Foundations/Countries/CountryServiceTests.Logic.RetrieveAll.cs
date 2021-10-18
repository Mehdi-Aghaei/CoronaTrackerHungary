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
            List<Country> storageCountries = randomCountries;
            List<Country> expectedCountries = storageCountries.DeepClone();

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllCountriesAsync())
                    .ReturnsAsync(storageCountries);
            // when
            List<Country> actualCountries =
                await this.countryService.RetrieveAllCountrieasAsync();

            // then
            actualCountries.Should().BeEquivalentTo(expectedCountries);

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllCountriesAsync,
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();

        }

    }
}
