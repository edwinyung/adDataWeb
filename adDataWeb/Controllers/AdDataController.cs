using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using adDataWeb.Interfaces;
using adDataWeb.Models;

namespace adDataWeb.Controllers
{

    [Route("api/[controller]")]
    public class AdDataController : Controller
    {
        private readonly IHttpClientAccessor client;

        public AdDataController(IHttpClientAccessor httpClientAccessor)
        {
            client = httpClientAccessor;
        }

        [HttpGet("[action]")]
        public async Task<List<Advertiser>> FullListAdvertisers(int page, int take, string sort)
        {
            try
            {
                string responseBody = await client.GetData();
                return JsonConvert.DeserializeObject<List<Advertiser>>(responseBody);

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
