using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using adDataWeb.Interfaces;

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

        public class Advertiser
        {
            public string Month { get; set; }
            public int PublicationId { get; set; }
            public string PublicationName { get; set; }
            public string ParentCompany { get; set; }
            public int ParentCompanyId { get; set; }
            public string BrandName { get; set; }
            public int BrandId { get; set; }
            public string ProductCategory { get; set; }
            public float AdPages { get; set; }
            public int EstPrintSpend { get; set; }
        }

    }
}
