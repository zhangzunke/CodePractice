using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLWeb.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    BarCode = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SellingPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.BarCode);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "BarCode", "SellingPrice", "Title" },
                values: new object[] { "123", 50m, "Headphone" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "BarCode", "SellingPrice", "Title" },
                values: new object[] { "456", 40m, "Keyboard" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "BarCode", "SellingPrice", "Title" },
                values: new object[] { "789", 100m, "Monitor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
