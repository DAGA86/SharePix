using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharePix.Data.Migrations
{
    public partial class AndTranslationsFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translation",
                columns: new[] { "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { "add.newFriend.title", 1, "Add new friend" },
                    { "add.newFriend.title", 2, "Adicionar novo amigo" },
                    { "addFriend.error", 1, " Error when adding friend!" },
                    { "addFriend.error", 2, "Erro ao adicionar amigo!" },
                    { "addFriend.success", 1, "Friend added successfully!" },
                    { "addFriend.success", 2, "Amigo adicionado com sucesso!" },
                    { "confirmDeleteEmail.message", 1, "Do you want to delete / rejest this friend?" },
                    { "confirmDeleteEmail.message", 2, "Pretende apagar/rejeitar este amigo?" },
                    { "delete.warning", 1, "Warning" },
                    { "delete.warning", 2, "Aviso" },
                    { "deleteFriend.error", 1, "Error deleting friend!" },
                    { "deleteFriend.error", 2, "Erro ao apagar amigo!" },
                    { "deleteFriend.success", 1, "Friend successfully deleted!" },
                    { "deleteFriend.success", 2, "Amigo apagado com sucesso!" },
                    { "email.content.newRegister", 1, "You've been sent a friend request. Login to your account or create one " },
                    { "email.content.newRegister", 2, "Foi-lhe enviado um pedido de amizade. Aceda à sua conta ou criar uma" },
                    { "email.subject.newRequest", 1, "New friend request" },
                    { "email.subject.newRequest", 2, "Novo pedido de amizade" },
                    { "friends.title", 1, "Friends" },
                    { "friends.title", 2, "Amigos" },
                    { "message.discovery", 1, "Discover the best place to share photos with your friends" },
                    { "message.discovery", 2, "Descubra o melhor local para partilhar fotografias com os seus amigos" },
                    { "message.welcome", 1, "Welcome to SharePix" },
                    { "message.welcome", 2, "Bem-vindo à SharePix" },
                    { "myList.title", 1, "My list" },
                    { "myList.title", 2, "Minha lista " },
                    { "requestFriend.alreadyAdded", 1, "Friend already added!" },
                    { "requestFriend.alreadyAdded", 2, "Amigo já adicionado!" },
                    { "requestFriend.error", 1, "Error when adding friend!" },
                    { "requestFriend.error", 2, "Erro ao enviar pedido!" },
                    { "requestFriend.success", 1, "Request sent successfully!" },
                    { "requestFriend.success", 2, "Pedido enviado com sucesso!" },
                    { "requests.title", 1, "Requests" },
                    { "requests.title", 2, "Pedidos" },
                    { "searchEmail.title", 1, "Search email:" },
                    { "searchEmail.title", 2, "Procurar por email:" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "add.newFriend.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "add.newFriend.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "addFriend.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "addFriend.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "addFriend.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "addFriend.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "confirmDeleteEmail.message", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "confirmDeleteEmail.message", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "delete.warning", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "delete.warning", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteFriend.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteFriend.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteFriend.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "deleteFriend.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content.newRegister", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.content.newRegister", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.subject.newRequest", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "email.subject.newRequest", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "friends.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "friends.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "message.discovery", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "message.discovery", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "message.welcome", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "message.welcome", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "myList.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "myList.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requestFriend.alreadyAdded", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requestFriend.alreadyAdded", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requestFriend.error", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requestFriend.error", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requestFriend.success", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requestFriend.success", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requests.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "requests.title", 2 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "searchEmail.title", 1 });

            migrationBuilder.DeleteData(
                table: "Translation",
                keyColumns: new[] { "Key", "LanguageId" },
                keyValues: new object[] { "searchEmail.title", 2 });
        }
    }
}
