using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedValuesForCombatLoop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DamagePoints", "Experience", "Gold", "Hitpoints" },
                values: new object[] { 5, 0, 0, 50 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Players");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DamagePoints", "Hitpoints" },
                values: new object[] { 4, 30 });
        }
    }
}
