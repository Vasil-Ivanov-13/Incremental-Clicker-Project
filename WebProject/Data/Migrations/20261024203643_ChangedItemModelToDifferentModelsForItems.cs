using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedItemModelToDifferentModelsForItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropColumn(
                name: "ArmorId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "DamagePoints",
                table: "Players",
                newName: "Strength");

            migrationBuilder.CreateTable(
                name: "ArmourItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    HealthPoints = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmourItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmourItems_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DamagePoints = table.Column<int>(type: "int", nullable: true),
                    StrengthModifier = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponItems_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "Strength",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ArmourItems_PlayerId",
                table: "ArmourItems",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeaponItems_PlayerId",
                table: "WeaponItems",
                column: "PlayerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmourItems");

            migrationBuilder.DropTable(
                name: "WeaponItems");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "Players",
                newName: "DamagePoints");

            migrationBuilder.AddColumn<int>(
                name: "ArmorId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CritModifier = table.Column<double>(type: "float", nullable: true),
                    DamagePoints = table.Column<int>(type: "int", nullable: true),
                    HealthPoints = table.Column<int>(type: "int", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArmorId", "DamagePoints", "IsAlive", "WeaponId" },
                values: new object[] { null, 5, true, null });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerId",
                table: "Items",
                column: "PlayerId");
        }
    }
}
