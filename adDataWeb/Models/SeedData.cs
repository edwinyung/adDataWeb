using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using adDataWeb.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace adDataWeb.Models
{
    public static class SeedData
    {

        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AdvertiserContext(
                serviceProvider.GetRequiredService<DbContextOptions<AdvertiserContext>>()))
            {
                // Look for any movies.
                if (context.Advertiser.Any())
                {
                    return;   // DB has been seeded
                }

                string startDate = "2011-01-01";
                string endDate = "2011-04-01";
                var _client = new HttpClient();
                _client.BaseAddress = new Uri($"https://api-c.mediaradar.com/HiringAssessment/PublicationAdActivity?startDate={startDate}&endDate={endDate}");
                _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "293d6276c7f44b9bbae21d85794656b5");

                IHttpClientAccessor client = new HttpClientAccessor(_client);
                string responseBody = await client.GetData();
                context.Advertiser.AddRange(JsonConvert.DeserializeObject<List<Advertiser>>(responseBody));

                context.SaveChanges();
            }
        }
    }
}
