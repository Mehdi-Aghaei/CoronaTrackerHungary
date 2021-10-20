using Xeptions;

namespace CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions
{
    public class InvalidCountryException : Xeption
    {
        public InvalidCountryException()
            : base(message:"Invalid country. please correct the errors and try again.")
        { }     
    }
}
