using System;
using Xeptions;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class FailedCountryDependencyException : Xeption
    {
        public FailedCountryDependencyException(Exception innerException)
            :base(message: "Failed teacher dependency error occurred, please contact support.",innerException)
        { }
    }
}
