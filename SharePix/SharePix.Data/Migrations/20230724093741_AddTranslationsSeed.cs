using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AddTranslationsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValues: new object[] { "uploadPhoto.description.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.description.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.location.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "uploadPhoto.location.maxLength", 2 });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "album.description.maxLength", 1, "Maximun 256 characters" },
                    { "album.description.maxLength", 2, " Máximo 256 caracteres " },
                    { "album.message.delete", 1, "Do you want to delete this album ? " },
                    { "album.message.delete", 2, "Deseja apagar este álbum?" },
                    { "album.message.warning", 1, "Warning" },
                    { "album.message.warning", 2, "Aviso" },
                    { "album.name.maxLength", 1, "Maximun 32 characters" },
                    { "album.name.maxLength", 2, "Máximo 32 caracteres" },
                    { "album.name.minLength", 1, "Minimun 1 character" },
                    { "album.name.minLength", 2, "Mínimo 1 caracter" },
                    { "deleteAlbum.error", 1, "Error deleting album!" },
                    { "deleteAlbum.error", 2, "Erro ao apagar álbum!" },
                    { "deleteAlbum.success", 1, "Album successfully deleted!" },
                    { "deleteAlbum.success", 2, "Álbum apagado com sucesso!" },
                    { "deletePhoto.error", 1, "Error deleting photo!" },
                    { "deletePhoto.error", 2, "Erro ao apagar foto!" },
                    { "deletePhoto.success", 1, "Photo successfully deleted!" },
                    { "deletePhoto.success", 2, "Foto apagada com sucesso!" },
                    { "editAlbum.error", 1, "Error changing album!" },
                    { "editAlbum.error", 2, "Erro ao editar álbum!" },
                    { "editAlbum.success", 1, "Album successfully edited!" },
                    { "editAlbum.success", 2, "Álbum editado com sucesso!" },
                    { "editAlbum.title", 1, "Edit album" },
                    { "editAlbum.title", 2, "Editar álbum" },
                    { "editPhoto.error", 1, "Error changing photo!" },
                    { "editPhoto.error", 2, "Erro ao alterar foto!" },
                    { "editPhoto.success", 1, "Photo successfully edited!" },
                    { "editPhoto.success", 2, "Foto editada com sucesso!" },
                    { "editPhoto.title", 1, "Edit photo" },
                    { "editPhoto.title", 2, "Editar foto" },
                    { "general.button.confirm", 1, "Confirm" },
                    { "general.button.confirm", 2, "Confirmar" },
                    { "inactiveAccount.error", 1, "Error when disabling account!" },
                    { "inactiveAccount.error", 2, " Erro ao desativar conta!" },
                    { "inactiveAccount.success", 1, "Account successfully disabled!" },
                    { "inactiveAccount.success", 2, "Conta desativada com sucesso!" },
                    { "photo.description.maxLength", 1, "Maximun 1000 characters" },
                    { "photo.description.maxLength", 2, " Máximo 1000 caracteres " },
                    { "photo.location.maxLength", 1, "Maximun 68 characters" },
                    { "photo.location.maxLength", 2, " Máximo 68 caracteres " },
                    { "photo.message.delete", 1, "Do you want to delete this photo?" },
                    { "photo.message.delete", 2, "Deseja apagar esta foto?" }
                });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[] { "photo.message.warning", 1, "Warning" });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[] { "photo.message.warning", 2, "Aviso" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.description.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.description.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.message.delete", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.message.delete", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.message.warning", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.message.warning", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.name.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.name.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.name.minLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "album.name.minLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteAlbum.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteAlbum.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteAlbum.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteAlbum.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deletePhoto.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deletePhoto.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deletePhoto.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deletePhoto.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editAlbum.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editAlbum.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editAlbum.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editAlbum.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editAlbum.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editAlbum.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editPhoto.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editPhoto.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editPhoto.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editPhoto.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editPhoto.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "editPhoto.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.confirm", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "general.button.confirm", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "inactiveAccount.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "inactiveAccount.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "inactiveAccount.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "inactiveAccount.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.description.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.description.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.location.maxLength", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.location.maxLength", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.message.delete", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.message.delete", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.message.warning", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "photo.message.warning", 2 });

            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "createAlbum.description.maxLength", 1, "Maximun 256 characters" },
                    { "createAlbum.description.maxLength", 2, " Máximo 256 caracteres " },
                    { "createAlbum.name.maxLength", 1, "Maximun 32 characters" },
                    { "createAlbum.name.maxLength", 2, "Máximo 32 caracteres" },
                    { "createAlbum.name.minLength", 1, "Minimun 1 character" },
                    { "createAlbum.name.minLength", 2, "Mínimo 1 caracter" },
                    { "uploadPhoto.description.maxLength", 1, "Maximun 1000 characters" },
                    { "uploadPhoto.description.maxLength", 2, " Máximo 1000 caracteres " },
                    { "uploadPhoto.location.maxLength", 1, "Maximun 68 characters" },
                    { "uploadPhoto.location.maxLength", 2, " Máximo 68 caracteres " }
                });
        }
    }
}
