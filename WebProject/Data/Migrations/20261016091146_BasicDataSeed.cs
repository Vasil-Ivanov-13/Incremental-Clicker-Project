using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class BasicDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "Id", "DamagePoints", "Hitpoints", "IsAlive", "Level" },
                values: new object[,]
                {
                    { 1, 2, 10, true, 1 },
                    { 2, 3, 15, true, 2 },
                    { 3, 4, 20, true, 3 },
                    { 4, 5, 40, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CharacterType", "DamagePoints", "Hitpoints", "IsAlive", "Level", "Name" },
                values: new object[] { 1, 0, 4, 30, true, 1, "JohnTestSouls" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
