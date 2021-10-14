using CoronaTrackerHungary.Web.Api.Brokers.API;
using CoronaTrackerHungary.Web.Api.Services.Foundations.Countries;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace CoronaTrackerHungary.Web.Api.Tests.Unit.Services.Foundations.Countries
{
    public partial class CountryServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly ICountryService countyService;
        public CountryServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();    
            this.countyService = new CountryService(apiBroker:this.apiBrokerMock.Object);

        }
        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();
        
    }
}
