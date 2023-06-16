using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false),
                    Weighted = table.Column<bool>(nullable: false),
                    ProductStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Barcode", "CategoryName", "Description", "Name", "ProductStatus", "Weighted" },
                values: new object[,]
                {
                    { new Guid("78254fac-f870-48e8-8b67-eca11aefd7ce"), "147258", "Samsung", "samsung laptop", "laptop", 2, true },
                    { new Guid("8851fc5e-6b3f-4407-9be0-7f5b439cb78b"), "147256", "Lenovo", "lenovo laptop", "laptop", 2, true },
                    { new Guid("6224f858-1a0e-44f8-b65b-788fe89dfb5e"), "147257", "Acer", "acer laptop", "laptop", 2, true },
                    { new Guid("cd5dcb76-3de9-4fcc-a45f-6bb91345beef"), "147255", "Apple", "apple laptop", "laptop", 2, true },
                    { new Guid("76e19dcf-b4e2-4418-8c20-59644b75916c"), "147259", "Dell", "dell laptop", "laptop", 2, true },
                    { new Guid("db2c61b6-9f1a-432b-ae26-34d059ccd18b"), "147239", "Dell", "dell laptop", "laptop", 3, true },
                    { new Guid("c960b8b7-51ac-41c5-aba9-d7c75a7915f9"), "147229", "Dell", "dell laptop", "laptop", 1, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
