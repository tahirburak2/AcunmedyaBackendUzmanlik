﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageUrl", "IsActive", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4105), "Bilgisayarlar, telefonlar ve diğer elektronik ürünler.", "/images/categories/elektronik.jpg", true, false, "Elektronik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4111), "Kadın, erkek ve çocuk giyim ürünleri.", "/images/categories/moda.jpg", true, false, "Moda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4113), "Ev dekorasyonu ve yaşam alanları için ürünler.", "/images/categories/ev-ve-yasam.jpg", true, false, "Ev & Yaşam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4114), "Outdoor ve spor yaparken kullanabileceğiniz ekipmanlar.", "/images/categories/spor-outdoor.jpg", true, false, "Spor & Outdoor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4115), "Araba aksesuarları ve yedek parçalar.", "/images/categories/otomotiv.jpg", false, false, "Otomotiv", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4117), "Farklı kategorilerde kitaplar.", "/images/categories/kitaplar.jpg", true, false, "Kitaplar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4118), "Sağlık ve güzellik ürünleri.", "/images/categories/saglik-kozmetik.jpg", true, false, "Sağlık & Kozmetik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4120), "Yiyecek ve içecek ürünleri.", "/images/categories/gida.jpg", true, false, "Gıda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4121), "Hobi, oyun ve eğlence ürünleri.", "/images/categories/hobi-eglence.jpg", false, false, "Hobi & Eğlence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4122), "Buzdolapları, çamaşır makineleri ve diğer büyük ev aletleri.", "/images/categories/beyaz-esya.jpg", true, true, "Beyaz Eşya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ImageUrl", "IsActive", "IsDeleted", "Name", "Price", "Properties", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4863), "/images/products/laptop.jpg", true, false, "Laptop", 1500.00m, "16GB RAM, 512GB SSD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4870), "/images/products/smartphone.jpg", true, false, "Smartphone", 800.00m, "128GB Storage, 6GB RAM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4872), "/images/products/tshirt.jpg", true, false, "T-Shirt", 20.00m, "100% Cotton, Size M", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4873), "/images/products/running_shoes.jpg", true, false, "Running Shoes", 60.00m, "Size 42, Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4878), "/images/products/refrigerator.jpg", true, false, "Refrigerator", 500.00m, "300L, Energy Class A++", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4879), "/images/products/novel_book.jpg", true, false, "Novel Book", 15.00m, "Fiction, 300 pages", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4880), "/images/products/face_cream.jpg", true, false, "Face Cream", 25.00m, "50ml, Anti-aging", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4882), "/images/products/organic_apple.jpg", true, false, "Organic Apple", 3.00m, "1kg, Fresh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4883), "/images/products/guitar.jpg", true, false, "Guitar", 120.00m, "Acoustic, 6 strings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4884), "/images/products/car_tire.jpg", true, false, "Car Tire", 70.00m, "195/65 R15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4888), "/images/products/smartwatch.jpg", true, false, "Smartwatch", 200.00m, "Heart Rate Monitor, GPS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4889), "/images/products/tablet.jpg", true, false, "Tablet", 300.00m, "10.1 inch, 64GB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4890), "/images/products/headphones.jpg", true, false, "Headphones", 150.00m, "Noise Cancelling", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4892), "/images/products/blender.jpg", true, false, "Blender", 50.00m, "500W, 1.5L", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4893), "/images/products/microwave.jpg", true, false, "Microwave", 100.00m, "800W, 20L", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4894), "/images/products/camera.jpg", true, false, "Camera", 700.00m, "24MP, 4K Video", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4895), "/images/products/watch.jpg", true, false, "Watch", 80.00m, "Analog, Water Resistant", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4897), "/images/products/backpack.jpg", true, false, "Backpack", 40.00m, "30L, Waterproof", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(4898), "/images/products/desk_lamp.jpg", true, false, "Desk Lamp", 25.00m, "LED, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5029), "/images/products/electric_kettle.jpg", true, false, "Electric Kettle", 30.00m, "1.7L, 2200W", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5031), "/images/products/gaming_chair.jpg", true, false, "Gaming Chair", 200.00m, "Ergonomic, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5032), "/images/products/sunglasses.jpg", true, false, "Sunglasses", 50.00m, "UV Protection", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5034), "/images/products/sneakers.jpg", true, false, "Sneakers", 70.00m, "Size 43, White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5035), "/images/products/coffee_maker.jpg", true, false, "Coffee Maker", 80.00m, "12 Cups, Programmable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5036), "/images/products/vacuum_cleaner.jpg", true, false, "Vacuum Cleaner", 150.00m, "Bagless, 2000W", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5038), "/images/products/air_conditioner.jpg", true, false, "Air Conditioner", 600.00m, "12000 BTU, Inverter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5040), "/images/products/electric_toothbrush.jpg", true, false, "Electric Toothbrush", 40.00m, "Rechargeable, 3 Modes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5041), "/images/products/hair_dryer.jpg", true, false, "Hair Dryer", 30.00m, "2000W, Ionic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5042), "/images/products/smart_tv.jpg", true, false, "Smart TV", 700.00m, "55 inch, 4K UHD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5043), "/images/products/gaming_console.jpg", true, false, "Gaming Console", 500.00m, "1TB, 4K HDR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5045), "/images/products/wireless_mouse.jpg", true, false, "Wireless Mouse", 25.00m, "Ergonomic, 1600 DPI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5046), "/images/products/keyboard.jpg", true, false, "Keyboard", 80.00m, "Mechanical, RGB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5047), "/images/products/monitor.jpg", true, false, "Monitor", 300.00m, "27 inch, 144Hz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5048), "/images/products/printer.jpg", true, false, "Printer", 150.00m, "All-in-One, Wireless", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5050), "/images/products/router.jpg", true, false, "Router", 100.00m, "Dual Band, Gigabit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5051), "/images/products/external_hard_drive.jpg", true, false, "External Hard Drive", 80.00m, "2TB, USB 3.0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5052), "/images/products/flash_drive.jpg", true, false, "Flash Drive", 20.00m, "64GB, USB 3.0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5054), "/images/products/power_bank.jpg", true, false, "Power Bank", 30.00m, "10000mAh, Fast Charging", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5055), "/images/products/wireless_charger.jpg", true, false, "Wireless Charger", 25.00m, "10W, Fast Charging", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5056), "/images/products/smart_light_bulb.jpg", true, false, "Smart Light Bulb", 20.00m, "RGB, WiFi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5057), "/images/products/security_camera.jpg", true, false, "Security Camera", 60.00m, "1080p, Night Vision", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5059), "/images/products/fitness_tracker.jpg", true, false, "Fitness Tracker", 50.00m, "Heart Rate Monitor, GPS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5061), "/images/products/electric_scooter.jpg", true, false, "Electric Scooter", 400.00m, "25km/h, 30km Range", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5062), "/images/products/drone.jpg", true, false, "Drone", 500.00m, "4K Camera, GPS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5063), "/images/products/action_camera.jpg", true, false, "Action Camera", 150.00m, "4K, Waterproof", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5065), "/images/products/electric_shaver.jpg", true, false, "Electric Shaver", 60.00m, "Rechargeable, Wet & Dry", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5066), "/images/products/hair_straightener.jpg", true, false, "Hair Straightener", 40.00m, "Ceramic, 200°C", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5067), "/images/products/electric_grill.jpg", true, false, "Electric Grill", 70.00m, "2000W, Non-Stick", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5069), "/images/products/rice_cooker.jpg", true, false, "Rice Cooker", 50.00m, "1.8L, Non-Stick", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5070), "/images/products/air_fryer.jpg", true, false, "Air Fryer", 100.00m, "3.5L, Digital", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5071), "/images/products/electric_blanket.jpg", true, false, "Electric Blanket", 40.00m, "150x200cm, 3 Heat Settings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5073), "/images/products/water_filter.jpg", true, false, "Water Filter", 30.00m, "10L, 5-Stage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5074), "/images/products/electric_heater.jpg", true, false, "Electric Heater", 50.00m, "2000W, Adjustable Thermostat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5075), "/images/products/dehumidifier.jpg", true, false, "Dehumidifier", 150.00m, "20L, Digital", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5076), "/images/products/humidifier.jpg", true, false, "Humidifier", 40.00m, "5L, Ultrasonic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5078), "/images/products/electric_fan.jpg", true, false, "Electric Fan", 30.00m, "16 inch, Oscillating", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5079), "/images/products/electric_iron.jpg", true, false, "Electric Iron", 40.00m, "2400W, Steam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5080), "/images/products/sewing_machine.jpg", true, false, "Sewing Machine", 100.00m, "Portable, 12 Stitches", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5082), "/images/products/electric_screwdriver.jpg", true, false, "Electric Screwdriver", 30.00m, "Rechargeable, 3.6V", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5086), "/images/products/cordless_drill.jpg", true, false, "Cordless Drill", 80.00m, "18V, 2 Batteries", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5087), "/images/products/tool_set.jpg", true, false, "Tool Set", 50.00m, "100 Pieces, Chrome Vanadium", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5088), "/images/products/lawn_mower.jpg", true, false, "Lawn Mower", 150.00m, "Electric, 1600W", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5089), "/images/products/garden_hose.jpg", true, false, "Garden Hose", 40.00m, "30m, Expandable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5091), "/images/products/bbq_grill.jpg", true, false, "BBQ Grill", 70.00m, "Charcoal, Portable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5092), "/images/products/tent.jpg", true, false, "Tent", 100.00m, "4 Person, Waterproof", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5093), "/images/products/sleeping_bag.jpg", true, false, "Sleeping Bag", 50.00m, "3 Season, Mummy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5095), "/images/products/camping_stove.jpg", true, false, "Camping Stove", 30.00m, "Portable, Gas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5096), "/images/products/hiking_backpack.jpg", true, false, "Hiking Backpack", 60.00m, "50L, Waterproof", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5097), "/images/products/binoculars.jpg", true, false, "Binoculars", 80.00m, "10x50, Waterproof", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5099), "/images/products/fishing_rod.jpg", true, false, "Fishing Rod", 40.00m, "Carbon Fiber, 2.1m", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5100), "/images/products/yoga_mat.jpg", true, false, "Yoga Mat", 20.00m, "6mm, Non-Slip", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5101), "/images/products/dumbbell_set.jpg", true, false, "Dumbbell Set", 50.00m, "20kg, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5134), "/images/products/treadmill.jpg", true, false, "Treadmill", 500.00m, "Folding, 2.5HP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5136), "/images/products/exercise_bike.jpg", true, false, "Exercise Bike", 200.00m, "Magnetic, 8 Resistance Levels", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5137), "/images/products/rowing_machine.jpg", true, false, "Rowing Machine", 300.00m, "Magnetic, Foldable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5138), "/images/products/elliptical_trainer.jpg", true, false, "Elliptical Trainer", 400.00m, "Magnetic, 8 Resistance Levels", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5139), "/images/products/weight_bench.jpg", true, false, "Weight Bench", 100.00m, "Adjustable, Foldable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5140), "/images/products/pull_up_bar.jpg", true, false, "Pull-Up Bar", 30.00m, "Doorway, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5142), "/images/products/resistance_bands.jpg", true, false, "Resistance Bands", 20.00m, "Set of 5, Different Resistance Levels", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5143), "/images/products/jump_rope.jpg", true, false, "Jump Rope", 10.00m, "Adjustable, Speed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5144), "/images/products/basketball.jpg", true, false, "Basketball", 25.00m, "Size 7, Indoor/Outdoor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5146), "/images/products/soccer_ball.jpg", true, false, "Soccer Ball", 20.00m, "Size 5, Synthetic Leather", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5147), "/images/products/tennis_racket.jpg", true, false, "Tennis Racket", 50.00m, "Graphite, Lightweight", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5148), "/images/products/badminton_set.jpg", true, false, "Badminton Set", 30.00m, "2 Rackets, 3 Shuttlecocks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5150), "/images/products/golf_clubs.jpg", true, false, "Golf Clubs", 500.00m, "Set of 12, Graphite", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5151), "/images/products/skateboard.jpg", true, false, "Skateboard", 40.00m, "31 inch, Maple", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5152), "/images/products/roller_skates.jpg", true, false, "Roller Skates", 60.00m, "Adjustable, Size 38-42", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5153), "/images/products/helmet.jpg", true, false, "Helmet", 30.00m, "Bike, Size M", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5155), "/images/products/knee_pads.jpg", true, false, "Knee Pads", 20.00m, "Set of 2, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5156), "/images/products/elbow_pads.jpg", true, false, "Elbow Pads", 20.00m, "Set of 2, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5157), "/images/products/wrist_guards.jpg", true, false, "Wrist Guards", 20.00m, "Set of 2, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5159), "/images/products/bike_lock.jpg", true, false, "Bike Lock", 25.00m, "Combination, Heavy Duty", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5160), "/images/products/bike_pump.jpg", true, false, "Bike Pump", 20.00m, "Portable, High Pressure", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5161), "/images/products/bike_light.jpg", true, false, "Bike Light", 30.00m, "Front and Rear, USB Rechargeable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5163), "/images/products/bike_bell.jpg", true, false, "Bike Bell", 10.00m, "Loud, Easy to Install", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5164), "/images/products/bike_basket.jpg", true, false, "Bike Basket", 40.00m, "Front, Wicker", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5165), "/images/products/bike_rack.jpg", true, false, "Bike Rack", 50.00m, "Rear, Adjustable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5166), "/images/products/bike_seat.jpg", true, false, "Bike Seat", 30.00m, "Comfort, Gel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5168), "/images/products/bike_gloves.jpg", true, false, "Bike Gloves", 20.00m, "Padded, Size L", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, new DateTime(2025, 1, 4, 11, 14, 44, 774, DateTimeKind.Utc).AddTicks(5169), "/images/products/bike_shorts.jpg", true, false, "Bike Shorts", 40.00m, "Padded, Size M", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 4, 4 },
                    { 10, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 5, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 10, 14 },
                    { 10, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 4, 18 },
                    { 3, 19 },
                    { 10, 20 },
                    { 4, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 10, 24 },
                    { 10, 25 },
                    { 10, 26 },
                    { 7, 27 },
                    { 7, 28 },
                    { 1, 29 },
                    { 1, 30 },
                    { 1, 31 },
                    { 1, 32 },
                    { 1, 33 },
                    { 1, 34 },
                    { 1, 35 },
                    { 1, 36 },
                    { 1, 37 },
                    { 1, 38 },
                    { 1, 39 },
                    { 1, 40 },
                    { 1, 41 },
                    { 4, 42 },
                    { 4, 43 },
                    { 4, 44 },
                    { 4, 45 },
                    { 7, 46 },
                    { 7, 47 },
                    { 10, 48 },
                    { 10, 49 },
                    { 10, 50 },
                    { 10, 51 },
                    { 10, 52 },
                    { 10, 53 },
                    { 10, 54 },
                    { 10, 55 },
                    { 10, 56 },
                    { 10, 57 },
                    { 10, 58 },
                    { 10, 59 },
                    { 10, 60 },
                    { 10, 61 },
                    { 10, 62 },
                    { 10, 63 },
                    { 10, 64 },
                    { 4, 65 },
                    { 4, 66 },
                    { 4, 67 },
                    { 4, 68 },
                    { 4, 69 },
                    { 4, 70 },
                    { 4, 71 },
                    { 4, 72 },
                    { 4, 73 },
                    { 4, 74 },
                    { 4, 75 },
                    { 4, 76 },
                    { 4, 77 },
                    { 4, 78 },
                    { 4, 79 },
                    { 4, 80 },
                    { 4, 81 },
                    { 4, 82 },
                    { 4, 83 },
                    { 4, 84 },
                    { 4, 85 },
                    { 4, 86 },
                    { 4, 87 },
                    { 4, 88 },
                    { 4, 89 },
                    { 4, 90 },
                    { 4, 91 },
                    { 4, 92 },
                    { 4, 93 },
                    { 4, 94 },
                    { 4, 95 },
                    { 4, 96 },
                    { 4, 97 },
                    { 4, 98 },
                    { 4, 99 },
                    { 4, 100 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
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
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
