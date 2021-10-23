using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using CoronaTrackerHungary.Web.Api.Brokers.API;
using CoronaTrackerHungary.Web.Api.Brokers.DateTimes;
using CoronaTrackerHungary.Web.Api.Brokers.Logging;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Services.Foundations.Countries;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;

namespace CoronaTrackerHungary.Web.Api.Tests.Unit.Services.Foundations.Countries
{
    public partial class CountryServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ICountryService countryService;
        public CountryServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.countryService = new CountryService(
                apiBroker: this.apiBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);

        }
        private static List<Country> CreateRandomCountries() =>
            CreateCountryFiller().Create(count: GetRandomNumber()).ToList();

        private static SqlException GetSqlException() =>
             (SqlException)FormatterServices.GetUninitializedObject(typeof
             (SqlException));
        private static string GetRandomMessage() =>
           new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        private static Filler<Country> CreateCountryFiller()
        {
            var filler = new Filler<Country>();
            filler.Setup()
                .OnType<DateTimeOffset>().Use(GetRandomDateTimeOffset());

            return filler;
        }

    }
}
