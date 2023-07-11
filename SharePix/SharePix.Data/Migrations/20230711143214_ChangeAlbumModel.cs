using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class ChangeAlbumModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_UserAccount_UserAccountId",
                table: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Album_UserAccountId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Album");

            migrationBuilder.CreateIndex(
                name: "IX_Album_OwnerId",
                table: "Album",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_UserAccount_OwnerId",
                table: "Album",
                column: "OwnerId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_UserAccount_OwnerId",
                table: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Album_OwnerId",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Album_UserAccountId",
                table: "Album",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_UserAccount_UserAccountId",
                table: "Album",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
