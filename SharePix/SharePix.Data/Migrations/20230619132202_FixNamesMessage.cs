using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class FixNamesMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.errorMessage.email", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.errorMessage.email", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.errorMessage.username", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.errorMessage.username", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.successMessage.account", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.successMessage.account", 2 });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "register.emailAlreadyExists", 1, "Email already exist. Please try another one" },
                    { "register.emailAlreadyExists", 2, "Email existente. Por favor tente outro" },
                    { "register.success", 1, "Account created successfully" },
                    { "register.success", 2, "Conta criada com sucesso" },
                    { "register.usernameAlreadyExists", 1, "Username already exist. Please try another one" },
                    { "register.usernameAlreadyExists", 2, "Nome de Utilizador existente. Por favor tente outro" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.emailAlreadyExists", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.emailAlreadyExists", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.usernameAlreadyExists", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.usernameAlreadyExists", 2 });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "register.errorMessage.email", 1, "Email already exist. Please try another one" },
                    { "register.errorMessage.email", 2, "Email existente. Por favor tente outro" },
                    { "register.errorMessage.username", 1, "Username already exist. Please try another one" },
                    { "register.errorMessage.username", 2, "Nome de Utilizador existente. Por favor tente outro" },
                    { "register.successMessage.account", 1, "Account created successfully" },
                    { "register.successMessage.account", 2, "Conta criada com sucesso" }
                });
        }
    }
}
