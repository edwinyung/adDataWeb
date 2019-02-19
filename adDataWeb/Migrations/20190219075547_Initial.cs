using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace adDataWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertiser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<string>(nullable: true),
                    PublicationId = table.Column<int>(nullable: false),
                    PublicationName = table.Column<string>(nullable: true),
                    ParentCompany = table.Column<string>(nullable: true),
                    ParentCompanyId = table.Column<int>(nullable: false),
                    BrandName = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false),
                    ProductCategory = table.Column<string>(nullable: true),
                    AdPages = table.Column<float>(nullable: false),
                    EstPrintSpend = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertiser", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertiser");
        }
    }
}
