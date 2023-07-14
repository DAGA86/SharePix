using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddedTranslationsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.maxLength", 2 },
                column: "Value",
                value: "Máximo 320 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.maxLength", 1 },
                column: "Value",
                value: "Maximun 120 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.maxLength", 2 },
                column: "Value",
                value: "Máximo 20 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.minLength", 1 },
                column: "Value",
                value: "Minimun 8 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.minLength", 2 },
                column: "Value",
                value: "Mínimo 8 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.regularExpression", 2 },
                column: "Value",
                value: "Mínimo 8 caracteres, pelo menos 1 letra maiúscula, 1 letra minúscula e 1 número");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.maxLength", 2 },
                column: "Value",
                value: "Máximo 32 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.minLength", 2 },
                column: "Value",
                value: "Mínimo 3 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.maxLength", 1 },
                column: "Value",
                value: "Maximun 32 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.maxLength", 2 },
                column: "Value",
                value: "Máximo 32 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.minLength", 1 },
                column: "Value",
                value: "Minimun 3 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.minLength", 2 },
                column: "Value",
                value: "Mínimo 3 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.maxLength", 1 },
                column: "Value",
                value: "Maximun 64 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.maxLength", 2 },
                column: "Value",
                value: "Máximo 64 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.minLength", 1 },
                column: "Value",
                value: "Minimun 3 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.minLength", 2 },
                column: "Value",
                value: "Mínimo 3 caracteres");

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "albums.title", 1, "Albums" },
                    { "albums.title", 2, "Álbuns" },
                    { "createAlbum.description.maxLength", 1, "Maximun 256 characters" },
                    { "createAlbum.description.maxLength", 2, " Máximo 256 caracteres " },
                    { "createAlbum.error", 1, "Error creating album!" },
                    { "createAlbum.error", 2, "Erro ao criar álbum!" },
                    { "createAlbum.name.maxLength", 1, "Maximun 32 characters" },
                    { "createAlbum.name.maxLength", 2, "Máximo 32 caracteres" },
                    { "createAlbum.name.minLength", 1, "Minimun 1 character" },
                    { "createAlbum.name.minLength", 2, "Mínimo 1 caracter" },
                    { "createAlbum.success", 1, "Album successfully created!" },
                    { "createAlbum.success", 2, "Álbum criado com sucesso!" },
                    { "createAlbum.title", 1, "Create album" },
                    { "createAlbum.title", 2, "Criar álbum" },
                    { "homepage.title", 1, "Home Page" },
                    { "homepage.title", 2, "Página principal" },
                    { "label.data", 1, "Date" },
                    { "label.data", 2, "Data" },
                    { "label.description", 1, "Description" },
                    { "label.description", 2, "Descrição" },
                    { "label.location", 1, "Location" },
                    { "label.location", 2, "Localização" },
                    { "label.name", 1, "Name" },
                    { "label.name", 2, "Nome" },
                    { "uploadPhoto.description.maxLength", 1, "Maximun 256 characters" },
                    { "uploadPhoto.description.maxLength", 2, " Máximo 256 caracteres " }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "uploadPhoto.error", 1, "Error uploading images" },
                    { "uploadPhoto.error", 2, "Erro ao carregar imagens" },
                    { "uploadPhoto.location.maxLength", 1, "Maximun 68 characters" },
                    { "uploadPhoto.location.maxLength", 2, " Máximo 68 caracteres " },
                    { "uploadPhoto.success", 1, "Uploaded successfully " },
                    { "uploadPhoto.success", 2, "Carregado com sucesso " },
                    { "uploadPhotos.title", 1, "Upload photos" },
                    { "uploadPhotos.title", 2, "Carregar foto" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "albums.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "albums.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.description.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.description.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.name.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.name.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.name.minLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.name.minLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "createAlbum.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "homepage.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "homepage.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.data", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.data", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.description", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.description", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.location", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.location", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.name", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "label.name", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.description.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.description.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.location.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.location.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhotos.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhotos.title", 2 });

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.maxLength", 2 },
                column: "Value",
                value: "Máximo de 320 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.maxLength", 1 },
                column: "Value",
                value: "Maximun is 120 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.maxLength", 2 },
                column: "Value",
                value: "Máximo de 120 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.minLength", 1 },
                column: "Value",
                value: "Minimun is 8 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.minLength", 2 },
                column: "Value",
                value: "Mínimo de 8 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "password.regularExpression", 2 },
                column: "Value",
                value: "Mínimo de 8 caracteres, pelo menos 1 letra maiúscula, 1 letra minúscula e 1 número");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.maxLength", 2 },
                column: "Value",
                value: "Máximo de 32 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.firstName.minLength", 2 },
                column: "Value",
                value: "Mínimo de 3 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.maxLength", 1 },
                column: "Value",
                value: "Maximun is 32 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.maxLength", 2 },
                column: "Value",
                value: "Máximo de 32 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.minLength", 1 },
                column: "Value",
                value: "Minimun is 3 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.lastName.minLength", 2 },
                column: "Value",
                value: "Mínimo de 3 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.maxLength", 1 },
                column: "Value",
                value: "Maximun is 64 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.maxLength", 2 },
                column: "Value",
                value: "Máximo de 64 caracteres");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.minLength", 1 },
                column: "Value",
                value: "Minimun is 3 characters");

            migrationBuilder.UpdateData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "register.username.minLength", 2 },
                column: "Value",
                value: "Mínimo de 3 caracteres");
        }
    }
}
