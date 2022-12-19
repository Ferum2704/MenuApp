using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ProxyService : IProxyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public string ServiceUrl => _serviceUrl;
        protected string _serviceUrl;
        public ProxyService(IHttpClientFactory httpClientFactory)
        { 
            _httpClientFactory = httpClientFactory;
        }
        private string ConcateUrl(string endpointUrl)
        {
            return _serviceUrl + endpointUrl;
        }
        public async Task<HttpResponseMessage> DeleteAsync(string endpointUrl)
        {
            var httpClient = _httpClientFactory.CreateClient();
            return await httpClient.DeleteAsync(ConcateUrl(endpointUrl));
        }

        public async Task<T> GetFromJsonAsync<T>(string endpointUrl)
        {
            var httpClient = _httpClientFactory.CreateClient();
            return await httpClient.GetFromJsonAsync<T>(ConcateUrl(endpointUrl));
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string endpointUrl, T obj)
        {
            var httpClient = _httpClientFactory.CreateClient();
            return await httpClient.PostAsJsonAsync(ConcateUrl(endpointUrl), obj);
        }

        public async Task<HttpResponseMessage> PutAsJsonAsync<T>(string endpointUrl, T obj)
        {
            var httpsClient = _httpClientFactory.CreateClient();
            return await httpsClient.PutAsJsonAsync(ConcateUrl(endpointUrl), obj);
        }
    }
}
