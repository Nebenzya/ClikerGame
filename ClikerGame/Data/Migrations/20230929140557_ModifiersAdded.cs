using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClikerGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityOfModifiers",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Modifier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Modificator = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifier", x => x.Id);
                    table.CheckConstraint("Name", "Name <> ''");
                });

            migrationBuilder.CreateTable(
                name: "ModifierUser",
                columns: table => new
                {
                    GamersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifiersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifierUser", x => new { x.GamersId, x.ModifiersId });
                    table.ForeignKey(
                        name: "FK_ModifierUser_Modifier_ModifiersId",
                        column: x => x.ModifiersId,
                        principalTable: "Modifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModifierUser_Users_GamersId",
                        column: x => x.GamersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModifierUser_ModifiersId",
                table: "ModifierUser",
                column: "ModifiersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModifierUser");

            migrationBuilder.DropTable(
                name: "Modifier");

            migrationBuilder.DropColumn(
                name: "QuantityOfModifiers",
                table: "Users");
        }
    }
}
