using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R54_M11_Class_05_Work_01.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OnSale", "Picture", "Price", "ProductName", "Size" },
                values: new object[,]
                {
                    { 1, null, "1.jpg", 1563m, "Product 1", 2 },
                    { 2, null, "2.jpg", 1695m, "Product 2", 4 },
                    { 3, null, "3.jpg", 1791m, "Product 3", 4 },
                    { 4, null, "4.jpg", 1606m, "Product 4", 4 },
                    { 5, null, "5.jpg", 1233m, "Product 5", 1 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "Date", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 4, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8831), 1, 100 },
                    { 2, new DateTime(2022, 8, 19, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8865), 2, 114 },
                    { 3, new DateTime(2022, 6, 15, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8876), 3, 119 },
                    { 4, new DateTime(2022, 7, 7, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8885), 4, 138 },
                    { 5, new DateTime(2022, 7, 6, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8895), 5, 147 },
                    { 6, new DateTime(2022, 6, 23, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8905), 1, 127 },
                    { 7, new DateTime(2022, 8, 12, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8915), 2, 156 },
                    { 8, new DateTime(2022, 8, 29, 17, 3, 56, 308, DateTimeKind.Local).AddTicks(8925), 3, 121 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
