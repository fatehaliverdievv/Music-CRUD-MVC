using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spotifycrud.Migrations
{
    /// <inheritdoc />
    public partial class changedtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_PlaylistNames_PlaylistNameId",
                table: "Playlists");

            migrationBuilder.DropTable(
                name: "PlaylistNames");

            migrationBuilder.RenameColumn(
                name: "PlaylistNameId",
                table: "Playlists",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_PlaylistNameId",
                table: "Playlists",
                newName: "IX_Playlists_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Playlists");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Playlists",
                newName: "PlaylistNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                newName: "IX_Playlists_PlaylistNameId");

            migrationBuilder.CreateTable(
                name: "PlaylistNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistNames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistNames_UserId",
                table: "PlaylistNames",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_PlaylistNames_PlaylistNameId",
                table: "Playlists",
                column: "PlaylistNameId",
                principalTable: "PlaylistNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
