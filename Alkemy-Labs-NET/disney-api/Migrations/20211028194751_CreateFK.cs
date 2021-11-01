using Microsoft.EntityFrameworkCore.Migrations;

namespace disney_api.Migrations
{
    public partial class CreateFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMovie",
                table: "mgenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "mgenders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMovie",
                table: "characters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "characters",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mgenders_MovieId",
                table: "mgenders",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_characters_MovieId",
                table: "characters",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_movies_MovieId",
                table: "characters",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mgenders_movies_MovieId",
                table: "mgenders",
                column: "MovieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_movies_MovieId",
                table: "characters");

            migrationBuilder.DropForeignKey(
                name: "FK_mgenders_movies_MovieId",
                table: "mgenders");

            migrationBuilder.DropIndex(
                name: "IX_mgenders_MovieId",
                table: "mgenders");

            migrationBuilder.DropIndex(
                name: "IX_characters_MovieId",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "IdMovie",
                table: "mgenders");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "mgenders");

            migrationBuilder.DropColumn(
                name: "IdMovie",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "characters");
        }
    }
}
