using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CoronaTrackerHungary.Web.Api.Models.Countries
{
    public class CountryInfo
    {
        [JsonProperty(PropertyName ="_id")]
        public int Id { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }
    }
}
