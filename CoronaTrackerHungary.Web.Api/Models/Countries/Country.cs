using Newtonsoft.Json;

namespace CoronaTrackerHungary.Web.Api.Models.Countries
{
    public class Country
    {
        [JsonProperty("country")]
        public string CountryName { get; set; }

        [JsonProperty("countryInfo")]
        public CountryInfo CountryInfo { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("cases")]
        public int Cases { get; set; }

        [JsonProperty("todayCases")]
        public int TodayCases { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("todayDeaths")]
        public int TodayDeaths { get; set; }

        [JsonProperty("recoverd")]
        public int Recoverd { get; set; }

        [JsonProperty("todayRecoverd")]
        public int TodayRecoverd { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("casesPerOneMillion")]
        public int CasesPerOneMillion { get; set; }

        [JsonProperty("deathsPerOneMillion")]
        public int DeathsPerOneMillion { get; set; }

        [JsonProperty("recoveredPerOneMillion")]
        public float RecoveredPerOneMillion { get; set; }

        [JsonProperty("criticalPerOneMillion")]
        public float criticalPerOneMillion { get; set; }
    }
}
