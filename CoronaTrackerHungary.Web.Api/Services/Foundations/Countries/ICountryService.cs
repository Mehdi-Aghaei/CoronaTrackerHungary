using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;

namespace CoronaTrackerHungary.Web.Api.Services.Foundations.Countries
{
    public interface ICountryService
    {
        ValueTask<List<Country>> RetrieveAllCountrieasAsync();
    }
}
