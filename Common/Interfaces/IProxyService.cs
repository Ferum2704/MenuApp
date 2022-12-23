using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IProxyService
    {
        public string ServiceUrl { get;}
        public Task<T> GetFromJsonAsync<T>(string url);
        public Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T obj);
        public Task<HttpResponseMessage> DeleteAsync(string url);
        public Task<HttpResponseMessage> PutAsJsonAsync<T>(string url, T obj);
    }
}
