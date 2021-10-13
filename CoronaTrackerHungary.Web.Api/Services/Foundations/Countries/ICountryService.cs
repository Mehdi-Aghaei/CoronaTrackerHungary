using CoronaTrackerHungary.Web.Api.Models.Countries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaTrackerHungary.Web.Api.Services.Foundations.Countries
{
    public interface ICountryService
    {
        ValueTask<List<Country>> RetrieveAllCountrieasAsync();
    }
}
