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

                var advertisers = (from row in _context.Advertiser select row).Take(5);

                advertisers = advertisers.OrderByDescending(s => s.AdPages).ThenByDescending(n => n.EstPrintSpend).ThenBy(l => l.ParentCompany);

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
                var advertisers = (from row in _context.Advertiser
                                   group row by new { row.ParentCompany, row.Month } into par
                                   select par).Take(5);

                //advertisers = advertisers.OrderByDescending(s => s.AdPages).ThenByDescending(n => n.EstPrintSpend).ThenBy(l => l.ParentCompany);

                //if (String.IsNullOrEmpty(page.ToString()) == true || page <= 0) page = 1;

                //return await PaginatedList<Advertiser>.CreateAsync(advertisers.AsNoTracking(), page, pageSize);

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
