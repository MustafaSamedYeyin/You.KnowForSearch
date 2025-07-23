using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Decks_DeckId",
                schema: "dbo",
                table: "Words");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                schema: "dbo",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Decks_DeckId",
                schema: "dbo",
                table: "Words",
                column: "DeckId",
                principalSchema: "dbo",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Decks_DeckId",
                schema: "dbo",
                table: "Words");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                schema: "dbo",
                table: "Words",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Decks_DeckId",
                schema: "dbo",
                table: "Words",
                column: "DeckId",
                principalSchema: "dbo",
                principalTable: "Decks",
                principalColumn: "Id");
        }
    }
}
