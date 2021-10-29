using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions;
using CoronaTrackerHungary.Web.Api.Services.Foundations.Countries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RESTFulSense.Controllers;

namespace CoronaTrackerHungary.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : RESTFulController
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [EnableQuery]
        public async ValueTask<ActionResult<Country>> Get()
        {
            try
            {
                List<Country> retrievedCountries =
                    await this.countryService.RetrieveAllCountrieasAsync();

                return Ok(retrievedCountries.AsQueryable());
            }
            catch (CountryDependencyException countryDependencyException)
            {
                return InternalServerError(countryDependencyException);
            }
            catch (CountryServiceException countryServiceException)
            {
                return InternalServerError(countryServiceException);
            }
        }
    }
}
