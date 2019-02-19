using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace adDataWeb.Interfaces
{
    //Encapsulate HttpClient Accessor and dispose it when done, so the app doesn't leak resources. Use dependency injection
    public interface IHttpClientAccessor
    {
        Task<string> GetData();
    }

    public class HttpClientAccessor : IHttpClientAccessor
    {

        public HttpClient _client { get; }

        public HttpClientAccessor(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetData()
        {
            try
            {
                string result = await _client.GetStringAsync(_client.BaseAddress);
                return result;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

    }
}
