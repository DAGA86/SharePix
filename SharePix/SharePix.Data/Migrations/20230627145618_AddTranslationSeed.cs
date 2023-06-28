using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddTranslationSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { " passwordChanged.error", 1, "Error! Please try again." },
                    { " passwordChanged.error", 2, "Erro! Por favor tente novamente." },
                    { "account.inactive", 1, "Account inactive" },
                    { "account.inactive", 2, "Conta inativa!" },
                    { "account.invalidCredentials", 1, " Invalid credentials!" },
                    { "account.invalidCredentials", 2, "Credenciais inválidas!" },
                    { "email.content", 1, "Please click the following link to reset your password:" },
                    { "email.content", 2, "Clique na seguinte ligação para redefinir a sua palavra-passe:" },
                    { "email.subject", 1, "Password Reset" },
                    { "email.subject", 2, "Redefinição da palavra-passe" },
                    { "forgottenPassword.title", 1, " Forgotten Password" },
                    { "forgottenPassword.title", 2, "Esqueceu-se da palavra-passe" },
                    { "general.button.send", 1, "Send" },
                    { "general.button.send", 2, "Enviar" },
                    { "general.info", 1, "Info" },
                    { "general.info", 2, "Informação" },
                    { "info.messageEmail", 1, " Please check your email to proceed. If you did not receive it, please check your spam." },
                    { "info.messageEmail", 2, "Por favor verifique o seu email para prosseguir. Caso não tenha recebido, verifique o spam." },
                    { "insertEmail.phrase", 1, " Please enter your email!" },
                    { "insertEmail.phrase", 2, "Por favor insira o seu email!" },
                    { "passwordChanged.success", 1, "Password changed successfully" },
                    { "passwordChanged.success", 2, "Palavra-passe alterada com sucesso" },
                    { "recoverPassword.title", 1, " Recover Password" },
                    { "recoverPassword.title", 2, "Recuperar palavra-passe" },
                    { "sendEmail.error", 1, "Error to sending! Please check your email address and try again." },
                    { "sendEmail.error", 2, "Erro ao enviar! Por favor, verifique o seu endereço de email e tente novamente." },
                    { "sendEmail.success", 1, "Email sent successfully" },
                    { "sendEmail.success", 2, "Email enviado com sucesso" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { " passwordChanged.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { " passwordChanged.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "account.inactive", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "account.inactive", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "account.invalidCredentials", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "account.invalidCredentials", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.subject", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.subject", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "forgottenPassword.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "forgottenPassword.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.send", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.send", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.info", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.info", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "info.messageEmail", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "info.messageEmail", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "insertEmail.phrase", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "insertEmail.phrase", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "passwordChanged.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "passwordChanged.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "recoverPassword.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "recoverPassword.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "sendEmail.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "sendEmail.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "sendEmail.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "sendEmail.success", 2 });
        }
    }
}
