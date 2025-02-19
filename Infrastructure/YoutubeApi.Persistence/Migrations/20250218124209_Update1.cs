using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 828, DateTimeKind.Local).AddTicks(3095), "Garden" });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 828, DateTimeKind.Local).AddTicks(8237), "Beauty, Games & Home" });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 828, DateTimeKind.Local).AddTicks(8486), "Tools, Kids & Industrial" });

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 18, 15, 42, 7, 829, DateTimeKind.Local).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 18, 15, 42, 7, 829, DateTimeKind.Local).AddTicks(5449));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 18, 15, 42, 7, 829, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 18, 15, 42, 7, 829, DateTimeKind.Local).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 841, DateTimeKind.Local).AddTicks(8847), "Eve okuma consequatur öyle ipsum.", "Salladı." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 841, DateTimeKind.Local).AddTicks(8968), "Adipisci beatae telefonu laboriosam suscipit.", "Aut ki." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 841, DateTimeKind.Local).AddTicks(9066), "Enim filmini quia incidunt anlamsız.", "Gülüyorum." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 876, DateTimeKind.Local).AddTicks(58), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 6.211219981642280m, 520.57m, "Handmade Frozen Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 2, 18, 15, 42, 7, 876, DateTimeKind.Local).AddTicks(154), "The Football Is Good For Training And Recreational Purposes", 8.776416780490960m, 170.73m, "Small Concrete Cheese" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categorys_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 984, DateTimeKind.Local).AddTicks(3721), "Jewelery & Beauty" });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 984, DateTimeKind.Local).AddTicks(3737), "Electronics" });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 984, DateTimeKind.Local).AddTicks(3750), "Kids" });

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 14, 11, 2, 9, 984, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 14, 11, 2, 9, 984, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 14, 11, 2, 9, 984, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 14, 11, 2, 9, 984, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 988, DateTimeKind.Local).AddTicks(4257), "Beğendim nemo aut accusantium sed.", "İure." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 988, DateTimeKind.Local).AddTicks(4360), "Dağılımı çıktılar qui dolayı et.", "Reprehenderit ullam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 988, DateTimeKind.Local).AddTicks(4426), "Filmini biber hesap bilgisayarı aliquid.", "Qui." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 992, DateTimeKind.Local).AddTicks(924), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 4.10064347367110m, 863.78m, "Handmade Rubber Fish" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 2, 14, 11, 2, 9, 992, DateTimeKind.Local).AddTicks(979), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 2.714769144144620m, 660.54m, "Unbranded Frozen Salad" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
