using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddSymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.forgottenPassword", 1 },
                column: "Value",
                value: "Forgotten password?");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.forgottenPassword", 2 },
                column: "Value",
                value: "Recuperar palavra-passe?");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.forgottenPassword", 1 },
                column: "Value",
                value: "Forgotten password");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.forgottenPassword", 2 },
                column: "Value",
                value: "Recuperar palavra-passe");
        }
    }
}
