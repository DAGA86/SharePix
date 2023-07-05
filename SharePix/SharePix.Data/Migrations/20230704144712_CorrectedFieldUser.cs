using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class CorrectedFieldUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_UserAccount_UserAccountId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_UserAccountId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Photo");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_OwnerId",
                table: "Photo",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_UserAccount_OwnerId",
                table: "Photo",
                column: "OwnerId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_UserAccount_OwnerId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_OwnerId",
                table: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Photo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserAccountId",
                table: "Photo",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_UserAccount_UserAccountId",
                table: "Photo",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
