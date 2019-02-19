using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adDataWeb.Models
{
    public class Advertiser
    {
        public int ID { get; set; }
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
