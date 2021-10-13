using CoronaTrackerHungary.Web.Api.Models.Configurations;
using Microsoft.Extensions.Configuration;
using RESTFulSense.Clients;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaTrackerHungary.Web.Api.Brokers.API
{
    public partial class ApiBroker : IApiBroker
    {
        private readonly IConfiguration configuration;
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;
        public ApiBroker(IConfiguration configuration,HttpClient httpClient)
        {
            this.configuration = configuration;
            this.httpClient = httpClient;
            this.apiClient = InitApiClient();
        }
        private async ValueTask<T> GetAsync<T>(string relativeUrl)=>
       
            await this.apiClient.GetContentAsync<T>(relativeUrl);
 
        private RESTFulApiFactoryClient InitApiClient()
        {
            LocalConfigurations localConfigurations = this.configuration.Get<LocalConfigurations>();
            string apiUrl = localConfigurations.ApiConfigurations.Url;

            this.httpClient.BaseAddress = new Uri(apiUrl);
            return new RESTFulApiFactoryClient(httpClient);
        }
    }
}
