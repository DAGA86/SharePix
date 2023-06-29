using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddSeedTranslationEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "general.button.upload", 1, "Upload" },
                    { "general.button.upload", 2, "Carregar" },
                    { "profile.changePassword.title", 1, "Change password" },
                    { "profile.changePassword.title", 2, "Mudar palavra-passe" },
                    { "profile.preview.title", 1, "Preview:" },
                    { "profile.preview.title", 2, "Pré-visualização:" },
                    { "profile.title", 1, "Profile" },
                    { "profile.title", 2, "Perfil" },
                    { "updateAccount.successMessage", 1, "Changes made successfully!" },
                    { "updateAccount.successMessage", 2, "Alterações realizadas com sucesso!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.upload", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.upload", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "profile.changePassword.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "profile.changePassword.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "profile.preview.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "profile.preview.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "profile.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "profile.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "updateAccount.successMessage", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "updateAccount.successMessage", 2 });
        }
    }
}
