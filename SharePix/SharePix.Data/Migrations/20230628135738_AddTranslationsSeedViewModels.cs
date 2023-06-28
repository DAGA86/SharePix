using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddTranslationsSeedViewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "confirmPassword.compare", 1, "Password not match" },
                    { "confirmPassword.compare", 2, "A palavra-passe não coincide" },
                    { "email.emailAddress", 1, "Email address inválid" },
                    { "email.emailAddress", 2, "Endereço de email inválido" },
                    { "email.maxLength", 1, "Maximun 320 characters" },
                    { "email.maxLength", 2, "Máximo de 320 caracteres" },
                    { "field.required", 1, "Field is required" },
                    { "field.required", 2, "Campo obrigatório" },
                    { "password.maxLength", 1, "Maximun is 120 characters" },
                    { "password.maxLength", 2, "Máximo de 120 caracteres" },
                    { "password.minLength", 1, "Minimun is 8 characters" },
                    { "password.minLength", 2, "Mínimo de 8 caracteres" },
                    { "password.regularExpression", 1, "Minimum 8 characters, at least 1 uppercase letter, 1 lowercase letter and 1 number" },
                    { "password.regularExpression", 2, "Mínimo de 8 caracteres, pelo menos 1 letra maiúscula, 1 letra minúscula e 1 número" },
                    { "register.firstName.maxLength", 1, "Maximun 32 characters" },
                    { "register.firstName.maxLength", 2, "Máximo de 32 caracteres" },
                    { "register.firstName.minLength", 1, "Minimun 3 characters" },
                    { "register.firstName.minLength", 2, "Mínimo de 3 caracteres" },
                    { "register.lastName.maxLength", 1, "Maximun is 32 characters" },
                    { "register.lastName.maxLength", 2, "Máximo de 32 caracteres" },
                    { "register.lastName.minLength", 1, "Minimun is 3 characters" },
                    { "register.lastName.minLength", 2, "Mínimo de 3 caracteres" },
                    { "register.username.maxLength", 1, "Maximun is 64 characters" },
                    { "register.username.maxLength", 2, "Máximo de 64 caracteres" },
                    { "register.username.minLength", 1, "Minimun is 3 characters" },
                    { "register.username.minLength", 2, "Mínimo de 3 caracteres" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "confirmPassword.compare", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "confirmPassword.compare", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.emailAddress", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.emailAddress", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "field.required", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "field.required", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.minLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.minLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.regularExpression", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.regularExpression", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.minLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.minLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.minLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.minLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.minLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.minLength", 2 });
        }
    }
}
