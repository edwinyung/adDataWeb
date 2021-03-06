﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using adDataWeb.Models;

namespace adDataWeb.Migrations
{
    [DbContext(typeof(AdvertiserContext))]
    [Migration("20190219075547_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("adDataWeb.Models.Advertiser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AdPages");

                    b.Property<int>("BrandId");

                    b.Property<string>("BrandName");

                    b.Property<int>("EstPrintSpend");

                    b.Property<string>("Month");

                    b.Property<string>("ParentCompany");

                    b.Property<int>("ParentCompanyId");

                    b.Property<string>("ProductCategory");

                    b.Property<int>("PublicationId");

                    b.Property<string>("PublicationName");

                    b.HasKey("ID");

                    b.ToTable("Advertiser");
                });
#pragma warning restore 612, 618
        }
    }
}
