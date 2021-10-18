using System;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class CountryServiceException : Exception
    {
        public CountryServiceException(Exception innerException)
            : base(message: "Country service error occurred, contact support.", innerException)
        {}
    }
}
