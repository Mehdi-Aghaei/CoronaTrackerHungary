using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions;
using Xunit;

namespace CoronaTrackerHungary.Web.Api.Tests.Unit.Services.Foundations.Countries
{
    public partial class CountryServiceTests
    {
        [Fact]
        public void ShouldThrowInvalidCountryExceptionIfCountryIsInvalid()
        {
            Country country = new Country();
            var expectedInvalidCountryException =
                new InvalidCountryException();


        }
    }
}
