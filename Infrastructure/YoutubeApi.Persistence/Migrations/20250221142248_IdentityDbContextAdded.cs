﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IdentityDbContextAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 124, DateTimeKind.Local).AddTicks(5510), "Movies" });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 124, DateTimeKind.Local).AddTicks(5530), "Clothing" });

            migrationBuilder.UpdateData(
                table: "Brans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 124, DateTimeKind.Local).AddTicks(5643), "Sports, Movies & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 21, 17, 22, 48, 125, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 21, 17, 22, 48, 125, DateTimeKind.Local).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 21, 17, 22, 48, 125, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2025, 2, 21, 17, 22, 48, 125, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 129, DateTimeKind.Local).AddTicks(8311), "İpsam rem quasi şafak ve.", "Batarya." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 129, DateTimeKind.Local).AddTicks(8406), "Kapının aut layıkıyla quae non.", "Ve yaptı." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Description", "Title" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 129, DateTimeKind.Local).AddTicks(8480), "Non quia batarya quae voluptatem.", "Sandalye." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 135, DateTimeKind.Local).AddTicks(9034), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 0.7558937685836060m, 770.28m, "Small Concrete Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 2, 21, 17, 22, 48, 135, DateTimeKind.Local).AddTicks(9101), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 3.165738344153770m, 132.21m, "Intelligent Granite Salad" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
        }
    }
}
