using System;
using System.Linq;
using System.Threading.Tasks;
using CoronaTrackerHungary.Web.Api.Models.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoronaTrackerHungary.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Country> Countries { get; set; }

        public async ValueTask<Country> InsertCountryAsync(Country country)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<Country> countryEntityEntry = 
                await broker.Countries.AddAsync(country);

            await broker.SaveChangesAsync();

            return countryEntityEntry.Entity;
        }

        public IQueryable<Country> SelectAllCountries() =>
            throw new NotImplementedException();

        public ValueTask<Country> UpdateCountryAsync(Country country) =>
            throw new NotImplementedException();
    }
}
