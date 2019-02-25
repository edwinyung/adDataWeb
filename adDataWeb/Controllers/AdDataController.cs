using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using adDataWeb.Interfaces;
using adDataWeb.Models;

namespace adDataWeb.Controllers
{

    [Route("api/[controller]")]
    public class AdDataController : Controller
    {
        private readonly IHttpClientAccessor client;
        private readonly AdvertiserContext _context;

        public AdDataController(IHttpClientAccessor httpClientAccessor, AdvertiserContext context)
        {
            client = httpClientAccessor;
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<List<Advertiser>> FullListAdvertisers(string sortOrder, int page, int pageSize)
        {
            try
            {
                //select * from the table in database
                var advertisers = from row in _context.Advertiser select row;

                if (String.IsNullOrEmpty(page.ToString()) == true || page <= 0) page = 1;

                return await PaginatedList<Advertiser>.CreateAsync(advertisers.AsNoTracking(), page, pageSize);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        [HttpGet("[action]")]
        public async Task<List<Advertiser>> TopBrandNames(string sortOrder, int page, int pageSize)
        {
            try
            {
                //select * from the table in database
                var advertisers = from row in _context.Advertiser where row.AdPages > 2 && row.ProductCategory == "Toiletries & Cosmetics > Hair Care" select row;

                advertisers = advertisers.OrderBy(s => s.BrandName);

                if (String.IsNullOrEmpty(page.ToString()) == true || page <= 0) page = 1;

                return await PaginatedList<Advertiser>.CreateAsync(advertisers.AsNoTracking(), page, pageSize);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        [HttpGet("[action]")]
        public async Task<List<Advertiser>> TopProductCategories(string sortOrder, int page, int pageSize)
        {
            try
            {

                var advertisers = _context.Advertiser.GroupBy(x => x.ProductCategory)
                            .Select(g => new
                            Advertiser
                            {
                                ProductCategory = g.Key,
                                EstPrintSpend = g.Sum(x => x.EstPrintSpend)
                            }).OrderByDescending(i => i.EstPrintSpend).Take(5);

                if (String.IsNullOrEmpty(page.ToString()) == true || page <= 0) page = 1;

                return await PaginatedList<Advertiser>.CreateAsync(advertisers.AsNoTracking(), page, pageSize);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        [HttpGet("[action]")]
        public async Task<List<Advertiser>> TopParentCompanies(string sortOrder, int page, int pageSize)
        {
            try
            {
                var advertisers = _context.Advertiser.GroupBy(x => new { x.ParentCompany, x.Month })
                          .Select(g => new
                          Advertiser
                          {
                              ParentCompany = g.Key.ParentCompany,
                              AdPages = g.Sum(q => q.AdPages),
                              EstPrintSpend = g.Sum(y => y.EstPrintSpend)
                          }).OrderByDescending(i => i.AdPages).ThenByDescending(d => d.EstPrintSpend).ThenBy(z => z.ParentCompany).Take(5);

                if (String.IsNullOrEmpty(page.ToString()) == true || page <= 0) page = 1;

                return await PaginatedList<Advertiser>.CreateAsync(advertisers.AsNoTracking(), page, pageSize);

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
