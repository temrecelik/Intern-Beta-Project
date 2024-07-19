﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { new Guid("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"), new DateTime(2024, 7, 19, 6, 58, 59, 325, DateTimeKind.Utc).AddTicks(5987), "Default Description", new DateTime(2024, 7, 19, 6, 58, 59, 325, DateTimeKind.Utc).AddTicks(5990), "Default Company" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { new Guid("a248dbf5-34d2-402c-b5d4-b882911d8768"), new DateTime(2024, 7, 19, 6, 58, 59, 326, DateTimeKind.Utc).AddTicks(5999), "Default Description", new DateTime(2024, 7, 19, 6, 58, 59, 326, DateTimeKind.Utc).AddTicks(6001), "Default Company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "LastUpdatedDate", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("a6cec149-f87b-43e0-b4e8-43fa24e05c58"), new DateTime(2024, 7, 19, 6, 58, 59, 326, DateTimeKind.Utc).AddTicks(7115), "Default Description", "Default@gmail.com", new DateTime(2024, 7, 19, 6, 58, 59, 326, DateTimeKind.Utc).AddTicks(7115), "Default Name", new byte[] { 152, 136, 82, 95, 66, 17, 199, 176, 207, 100, 251, 99, 93, 61, 50, 22, 84, 134, 56, 128, 73, 91, 225, 65, 162, 220, 33, 212, 25, 9, 24, 70, 121, 201, 219, 203, 95, 47, 154, 134, 111, 98, 101, 3, 52, 156, 139, 194, 199, 17, 144, 64, 217, 235, 160, 208, 197, 179, 45, 134, 80, 189, 186, 67 }, new byte[] { 45, 221, 236, 59, 114, 56, 140, 4, 185, 187, 18, 252, 136, 22, 176, 71, 98, 15, 89, 164, 251, 46, 45, 228, 197, 67, 119, 85, 89, 1, 159, 244, 167, 175, 121, 205, 166, 141, 135, 90, 161, 13, 89, 100, 138, 60, 192, 17, 115, 10, 142, 25, 255, 184, 129, 48, 255, 5, 214, 105, 93, 193, 51, 35, 14, 90, 134, 4, 194, 137, 103, 9, 62, 31, 202, 92, 222, 139, 247, 79, 215, 195, 228, 179, 51, 155, 124, 71, 113, 102, 30, 56, 46, 245, 157, 52, 135, 16, 253, 126, 43, 250, 74, 195, 167, 236, 95, 86, 64, 150, 212, 87, 76, 226, 36, 57, 224, 119, 238, 233, 66, 2, 30, 26, 46, 98, 194, 31 } });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "LastUpdatedDate", "Name", "OrderStatus", "ProductCount", "TotalPrice", "UnitPrice", "UserId" },
                values: new object[] { new Guid("3419f0b4-29ed-4603-a6af-80838c5cacdd"), new Guid("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"), new DateTime(2024, 7, 19, 6, 58, 59, 325, DateTimeKind.Utc).AddTicks(6367), new DateTime(2024, 7, 19, 6, 58, 59, 325, DateTimeKind.Utc).AddTicks(6367), "Default Company", 0, 100, 1000m, 10m, new Guid("a6cec149-f87b-43e0-b4e8-43fa24e05c58") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "Description", "LastUpdatedDate", "Name", "Price", "ProductCategoryId", "StockCount" },
                values: new object[] { new Guid("b520d963-aad4-4df9-b0ec-e89f5c82d52d"), new Guid("d8d6dad3-c8fc-443e-a02b-24ae0b9df15c"), new DateTime(2024, 7, 19, 6, 58, 59, 326, DateTimeKind.Utc).AddTicks(6261), "Default Description", new DateTime(2024, 7, 19, 6, 58, 59, 326, DateTimeKind.Utc).AddTicks(6261), "Default Name", 100m, new Guid("a248dbf5-34d2-402c-b5d4-b882911d8768"), 100 });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("3419f0b4-29ed-4603-a6af-80838c5cacdd"), new Guid("b520d963-aad4-4df9-b0ec-e89f5c82d52d") });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
