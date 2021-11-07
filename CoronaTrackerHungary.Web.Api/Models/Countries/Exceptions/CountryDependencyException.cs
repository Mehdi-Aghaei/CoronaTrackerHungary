using System;
using Xeptions;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class CountryDependencyException : Xeption
    {
        public CountryDependencyException(Xeption innerException)
            : base(message: "Country dependency error occurred, contact support.", innerException)
        { }
    }
}
