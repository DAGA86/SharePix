using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class CorrectionErroTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "confirmDeleteEmail.message", 2 },
                column: "Value",
                value: "Pretende apagar / rejeitar este amigo?");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "confirmDeleteEmail.message", 2 },
                column: "Value",
                value: "Pretende apagar/rejeitar este amigo?");
        }
    }
}
