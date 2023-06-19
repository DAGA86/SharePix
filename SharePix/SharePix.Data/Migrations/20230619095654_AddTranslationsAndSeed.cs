using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddTranslationsAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => new { x.Key, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_Translation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Culture", "Name" },
                values: new object[] { 1, "en-US", "English (United States)" });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Culture", "Name" },
                values: new object[] { 2, "pt-PT", "Portuguese (Portugal)" });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "general.button.back", 1, "Back" },
                    { "general.button.back", 2, "Voltar" },
                    { "general.button.cancel", 1, "Cancel" },
                    { "general.button.cancel", 2, "Cancelar" },
                    { "general.button.create", 1, "Create" },
                    { "general.button.create", 2, "Criar" },
                    { "general.button.delete", 1, "Delete" },
                    { "general.button.delete", 2, "Eliminar" },
                    { "general.button.edit", 1, "Edit" },
                    { "general.button.edit", 2, "Editar" },
                    { "general.button.login", 1, "Login" },
                    { "general.button.login", 2, "Entrar" },
                    { "general.button.save", 1, "Save" },
                    { "general.button.save", 2, "Salvar" },
                    { "label.confirmPassword", 1, "Confirm Password" },
                    { "label.confirmPassword", 2, "Confirmar Palavra-passe" },
                    { "label.email", 1, "Email" },
                    { "label.email", 2, "Email" },
                    { "label.firstName", 1, "First Name" },
                    { "label.firstName", 2, "Nome" },
                    { "label.lastName", 1, "Last Name" },
                    { "label.lastName", 2, "Apelido" },
                    { "label.password", 1, "Password" },
                    { "label.password", 2, "Palavra-passe" },
                    { "label.username", 1, "Username" },
                    { "label.username", 2, "Nome de Utilizador" },
                    { "label.usernameOrEmail", 1, "Username Or Email" },
                    { "label.usernameOrEmail", 2, "Nome de Utilizador Ou Email" },
                    { "login.title", 1, "Login" },
                    { "login.title", 2, "Entrar" },
                    { "register.title", 1, "Register" },
                    { "register.title", 2, "Registar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_LanguageId",
                table: "Translation",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
