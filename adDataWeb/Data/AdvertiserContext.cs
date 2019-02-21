using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace adDataWeb.Models
{
    public class AdvertiserContext : DbContext
    {
        public AdvertiserContext(DbContextOptions<AdvertiserContext> options)
            : base(options)
        {
        }

        public DbSet<Advertiser> Advertiser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertiser>().ToTable("Advertiser", "dbo");
        }

    }
}
