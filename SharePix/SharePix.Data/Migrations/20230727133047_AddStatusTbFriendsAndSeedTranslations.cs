using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddStatusTbFriendsAndSeedTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Friend",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "add.tags", 1, "Add tags" },
                    { "add.tags", 2, "Adicionar etiquetas" },
                    { "uploadPhotos.title", 1, "Upload photos" },
                    { "uploadPhotos.title", 2, "Carregar fotos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "add.tags", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "add.tags", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhotos.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhotos.title", 2 });

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Friend");
        }
    }
}
