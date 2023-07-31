using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddTranslationRequestEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content.newRegister", 1 },
                column: "Value",
                value: "You've been sent a friend request. Login to your account or create one!");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content.newRegister", 2 },
                column: "Value",
                value: "Foi-lhe enviado um pedido de amizade. Aceda à sua conta ou criar uma!");

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "sendEmail.request", 1, "Request sent successfully. Waiting for it to be accepted." },
                    { "sendEmail.request", 2, "Pedido enviado com sucesso. Aguarde que seja aceite." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "sendEmail.request", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "sendEmail.request", 2 });

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content.newRegister", 1 },
                column: "Value",
                value: "You've been sent a friend request. Login to your account or create one ");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content.newRegister", 2 },
                column: "Value",
                value: "Foi-lhe enviado um pedido de amizade. Aceda à sua conta ou criar uma");
        }
    }
}
