using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using CoronaTrackerHungary.Web.Api.Models.Countries.Exceptions;
using CoronaTrackerHungary.Web.Api.Services.Foundations.Countries;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async ValueTask<ActionResult<List<Country>>> GetAllCountriesAsync()
        {
            try
            {
                List<Country> retrievedCountries =
                    await this.countryService.RetrieveAllCountrieasAsync();

                return Ok(retrievedCountries);
            }
            catch(CountryDependencyException countryDependencyException)
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
