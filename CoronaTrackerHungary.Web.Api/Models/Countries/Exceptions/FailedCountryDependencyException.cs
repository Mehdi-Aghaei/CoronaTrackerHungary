using System;
using Xeptions;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class FailedCountryDependencyException : Xeption
    {
        public FailedCountryDependencyException(Exception innerException)
            : base(message: "Failed country dependency error occurred, please contact support.", innerException)
        { }
    }
}
