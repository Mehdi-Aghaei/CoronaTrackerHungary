using System;
using Xeptions;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class FailedCountryServiceException : Xeption
    {
        public FailedCountryServiceException(Exception innerException)
            : base(message: "Failed country error occurred, please contact support", innerException)
        { }
    }
}
