using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectRyan.Migrations
{
    /// <inheritdoc />
    public partial class CreateGamingStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Laptops" },
                    { 2, "Desktops" },
                    { 3, "Monitors" },
                    { 4, "Keyboards" },
                    { 5, "Headsets" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "ProductBrand", "ProductModel", "ProductPrice" },
                values: new object[,]
                {
                    { 1, 1, "ASUS", "TUF DASH F15", 1299.99 },
                    { 2, 2, "Corsair", "VENGEANCE i7200 Gaming PC", 1999.99 },
                    { 3, 3, "Samsung", "27in Odyssey G32A FHD 1ms 165Hz Gaming Monitor w/ Free Sync", 189.99000000000001 },
                    { 4, 4, "Logitech", "G Pro Mechanical Gaming Keyboard", 90.989999999999995 },
                    { 5, 5, "Logitech", "G733 Lightspeed Wireless Gaming Headset w/ Suspension Headband, Lightsync RGB, Blue Voice Mic Technology - Black", 133.99000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
