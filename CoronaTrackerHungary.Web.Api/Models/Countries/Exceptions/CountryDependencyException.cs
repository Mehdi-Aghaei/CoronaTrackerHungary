using System;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class CountryDependencyException : Exception
    {
        public CountryDependencyException(Exception innerException)
            : base(message: "Country dependency error occurred, contact support.", innerException)
        { }
    }
}
