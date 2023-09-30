using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClikerGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiersAdded_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModifierUser");

            migrationBuilder.DropColumn(
                name: "QuantityOfModifiers",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserModifier",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifiersId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityOfModifiers = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModifier", x => new { x.UsersId, x.ModifiersId });
                    table.ForeignKey(
                        name: "FK_UserModifier_Modifier_ModifiersId",
                        column: x => x.ModifiersId,
                        principalTable: "Modifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserModifier_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserModifier_ModifiersId",
                table: "UserModifier",
                column: "ModifiersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModifier");

            migrationBuilder.AddColumn<int>(
                name: "QuantityOfModifiers",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
    }
}
