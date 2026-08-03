using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpiceFlow_Stock_Manager.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spices",
                columns: table => new
                {
                    SpiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpiceName = table.Column<string>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Sales = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    ScovilleRating = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spices", x => x.SpiceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    IsManager = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cart = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ETA = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Spices_SpiceId",
                        column: x => x.SpiceId,
                        principalTable: "Spices",
                        principalColumn: "SpiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Spices",
                columns: new[] { "SpiceId", "ExpiryDate", "ImageUrl", "Origin", "Price", "Sales", "ScovilleRating", "SpiceName", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/beHWs9b.jpeg", "Mexico", 15, 75, 100000, "Habanero", 150 },
                    { 2, new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/8NQXwNE.jpeg", "Mexico", 0, 120, 8000, "Jalapeno", 300 },
                    { 3, new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/OxvJXwy.jpeg", "India", 14, 30, 1000000, "Ghost Pepper", 50 },
                    { 4, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/QaeGKvO.jpeg", "French Guiana", 9, 90, 50000, "Cayenne", 200 },
                    { 5, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/wcnPUFM.jpeg", "Mexico", 8, 60, 2500, "Serrano", 180 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Cart", "Email", "IsManager", "Password", "PhoneNumber", "PostalCode", "UserName" },
                values: new object[,]
                {
                    { 1, "123 Spice St, Flavor Town", "", "spicelover99@hotmail.com", false, "1234", "555-123-2020", "L2D 3D1", "spicelover99" },
                    { 2, "456 Heat Ave, Spice City", "", "pepperenjoyer@gmail.com", false, "1234", "647-090-2383", "R3C 8N9", "pepperenjoyer" },
                    { 3, "789 Fire Blvd, Pepperville", "", "heatfanatic@hotmail.com", false, "1234", "401-398-3874", "U2C 9A7", "heatfan" },
                    { 4, "321 Flame Rd, Chili Town", "", "spicyguy@spicemail.ca", false, "1234", "212-932-5294", "X8N 6F5", "spiceman" },
                    { 5, "654 Zest Ln, Aroma City", "", "zestfest@mail.ca", false, "1234", "901-219-7391", "Z1Z 2M3", "saffronman" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ETA", "OrderDate", "SpiceId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 3, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, new DateTime(2025, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SpiceId",
                table: "Orders",
                column: "SpiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Spices");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
