using System;
using Xeptions;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class CountryServiceException : Xeption
    {
        public CountryServiceException(Exception innerException)
            : base(message: "Country service error occurred, contact support.", innerException)
        { }
    }
}
