using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SharePix.Data.Contexts;
using SharePix.Data.Models;

namespace SharePix.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAccount>().HasIndex(x => x.Username).IsUnique();
            builder.Entity<UserAccount>().HasIndex(x => x.Email).IsUnique();

            builder.Entity<UserAccount>().HasMany(x => x.FriendsAddedByThis).WithOne(x => x.UserAccount);
            builder.Entity<UserAccount>().HasMany(x => x.FriendsAddedThis).WithOne(x => x.FriendAccount);
            builder.Entity<Friend>().HasKey(x => new { x.UserAccountId, x.FriendAccountId });

            builder.Entity<UserAccount>().HasMany(x => x.PhotoPersonTags).WithOne(x => x.Person);
            builder.Entity<Photo>().HasMany(x => x.PersonTags).WithOne(x => x.Photo);
            builder.Entity<PhotoPersonTag>().HasKey(x => new { x.PhotoId, x.PersonId });

            builder.Entity<Photo>().HasMany(x => x.TextTags).WithOne(x => x.Photo);
            builder.Entity<TextTag>().HasMany(x => x.PhotoTextTags).WithOne(x => x.Tag);
            builder.Entity<PhotoTextTag>().HasKey(x => new { x.PhotoId, x.TagId });

            builder.Entity<Group>().HasMany(x => x.UserGroups).WithOne(x => x.Group);
            builder.Entity<UserAccount>().HasMany(x => x.UserGroups).WithOne(x => x.User);
            builder.Entity<UserGroup>().HasKey(x => new { x.GroupId, x.UserId });

            builder.Entity<Translation>().HasKey(x => new { x.Key, x.LanguageId });


            // for the other conventions, we do a metadata model loop
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            // ###### SEED ######

            builder.Entity<Language>().HasData(new Language { Id = 1, Name = "English (United States)", Culture = "en-US" });
            builder.Entity<Language>().HasData(new Language { Id = 2, Name = "Portuguese (Portugal)", Culture = "pt-PT" });

            builder.Entity<Translation>().HasData(new Translation { Key = "register.title", Value = "Register", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "login.title", Value = "Login", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.login", Value = "Login", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.create", Value = "Create", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.createAccount", Value = "Create account", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.forgottenPassword", Value = "Forgotten password?", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.cancel", Value = "Cancel", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.edit", Value = "Edit", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.delete", Value = "Delete", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.save", Value = "Save", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.back", Value = "Back", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.firstName", Value = "First Name", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.lastName", Value = "Last Name", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.username", Value = "Username", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.email", Value = "Email", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.password", Value = "Password", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.confirmPassword", Value = "Confirm Password", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.usernameOrEmail", Value = "Username Or Email", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.emailAlreadyExists", Value = "Email already exist. Please try another one", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.usernameAlreadyExists", Value = "Username already exist. Please try another one", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.success", Value = "Account created successfully", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.subject", Value = "Password Reset", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.send", Value = "Send", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "sendEmail.success", Value = "Email sent successfully", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "sendEmail.error", Value = "Error to sending! Please check your email address and try again.", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.content", Value = "Please click the following link to reset your password:", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "passwordChanged.success", Value = "Password changed successfully", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = " passwordChanged.error", Value = "Error! Please try again.", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "account.inactive", Value = "Account inactive", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "account.invalidCredentials", Value = " Invalid credentials!", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "recoverPassword.title", Value = " Recover Password", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "forgottenPassword.title", Value = " Forgotten Password", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "insertEmail.phrase", Value = " Please enter your email!", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.info", Value = "Info", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "info.messageEmail", Value = " Please check your email to proceed. If you did not receive it, please check your spam.", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "field.required", Value = "Field is required", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.firstName.maxLength", Value = "Maximun 32 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.firstName.minLength", Value = "Minimun 3 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.lastName.maxLength", Value = "Maximun is 32 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.lastName.minLength", Value = "Minimun is 3 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.username.maxLength", Value = "Maximun is 64 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.username.minLength", Value = "Minimun is 3 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.regularExpression", Value = "Email address inválid! E.g: example@example.com", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.maxLength", Value = "Maximun 320 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "password.maxLength", Value = "Maximun is 120 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "password.minLength", Value = "Minimun is 8 characters", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "password.regularExpression", Value = "Minimum 8 characters, at least 1 uppercase letter, 1 lowercase letter and 1 number", LanguageId = 1 });
            builder.Entity<Translation>().HasData(new Translation { Key = "confirmPassword.compare", Value = "Password not match", LanguageId = 1 });

            builder.Entity<Translation>().HasData(new Translation { Key = "register.title", Value = "Registar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "login.title", Value = "Entrar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.login", Value = "Entrar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.create", Value = "Criar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.createAccount", Value = "Criar conta", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.forgottenPassword", Value = "Recuperar palavra-passe?", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.cancel", Value = "Cancelar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.edit", Value = "Editar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.delete", Value = "Eliminar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.save", Value = "Salvar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.back", Value = "Voltar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.firstName", Value = "Nome", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.lastName", Value = "Apelido", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.username", Value = "Nome de Utilizador", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.email", Value = "Email", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.password", Value = "Palavra-passe", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.confirmPassword", Value = "Confirmar Palavra-passe", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "label.usernameOrEmail", Value = "Nome de Utilizador Ou Email", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.emailAlreadyExists", Value = "Email existente. Por favor tente outro", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.usernameAlreadyExists", Value = "Nome de Utilizador existente. Por favor tente outro", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.success", Value = "Conta criada com sucesso", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.subject", Value = "Redefinição da palavra-passe", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.send", Value = "Enviar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "sendEmail.success", Value = "Email enviado com sucesso", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "sendEmail.error", Value = "Erro ao enviar! Por favor, verifique o seu endereço de email e tente novamente.", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.content", Value = "Clique na seguinte ligação para redefinir a sua palavra-passe:", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "passwordChanged.success", Value = "Palavra-passe alterada com sucesso", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = " passwordChanged.error", Value = "Erro! Por favor tente novamente.", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "account.inactive", Value = "Conta inativa!", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "account.invalidCredentials", Value = "Credenciais inválidas!", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "recoverPassword.title", Value = "Recuperar palavra-passe", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "forgottenPassword.title", Value = "Esqueceu-se da palavra-passe", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "insertEmail.phrase", Value = "Por favor insira o seu email!", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.info", Value = "Informação", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "info.messageEmail", Value = "Por favor verifique o seu email para prosseguir. Caso não tenha recebido, verifique o spam.", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "field.required", Value = "Campo obrigatório", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.firstName.maxLength", Value = "Máximo de 32 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.firstName.minLength", Value = "Mínimo de 3 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.lastName.maxLength", Value = "Máximo de 32 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.lastName.minLength", Value = "Mínimo de 3 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.username.maxLength", Value = "Máximo de 64 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "register.username.minLength", Value = "Mínimo de 3 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.regularExpression", Value = "Endereço de email inválido! Ex: exemplo@exemplo.pt", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "email.maxLength", Value = "Máximo de 320 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "password.maxLength", Value = "Máximo de 120 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "password.minLength", Value = "Mínimo de 8 caracteres", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "password.regularExpression", Value = "Mínimo de 8 caracteres, pelo menos 1 letra maiúscula, 1 letra minúscula e 1 número", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "confirmPassword.compare", Value = "A palavra-passe não coincide", LanguageId = 2 });

            base.OnModelCreating(builder);
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PhotoPersonTag> PhotoPersonTags { get; set; }
        public DbSet<PhotoTextTag> PhotoTextTags { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<TextTag> TextTags { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Language> Languages { get; set; }


    }
}

////TODO delete
//public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
//{
//    public DatabaseContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
//        optionsBuilder.UseSqlServer("Server=LAPTOP-SONIA;Database=SharePix;User Id=sa;Password=developer;MultipleActiveResultSets=true");

//        return new DatabaseContext(optionsBuilder.Options);
//    }
//}


//builder.Entity<Translation>().HasData(new Translation { Key = "login.usernameOrEmail.required", Value = "Field username or email is required", LanguageId = 1 });
// builder.Entity<Translation>().HasData(new Translation { Key = "register.firstName.required", Value = "Field first Name is required", LanguageId = 1 });
//builder.Entity<Translation>().HasData(new Translation { Key = "register.lastName.required", Value = "Field last name is required", LanguageId = 1 });
//builder.Entity<Translation>().HasData(new Translation { Key = "register.username.required", Value = "Field username is required", LanguageId = 1 });
//builder.Entity<Translation>().HasData(new Translation { Key = "email.required", Value = "Field email is required", LanguageId = 1 });
//builder.Entity<Translation>().HasData(new Translation { Key = "password.required", Value = "Field password is required", LanguageId = 1 });
//builder.Entity<Translation>().HasData(new Translation { Key = "confirmPassword.required", Value = "Field confirmation password is required", LanguageId = 1 });

//builder.Entity<Translation>().HasData(new Translation { Key = "login.usernameOrEmail.required", Value = "Nome de utilizador ou email é obrigatório", LanguageId = 2 });
//builder.Entity<Translation>().HasData(new Translation { Key = "register.firstName.required", Value = "Campo nome é obrigatório", LanguageId = 2 });
//builder.Entity<Translation>().HasData(new Translation { Key = "register.lastName.required", Value = "O campo apelido é obrigatório", LanguageId = 2 });
//builder.Entity<Translation>().HasData(new Translation { Key = "register.username.required", Value = "Campo nome de utilizador é obrigatório", LanguageId = 2 });
// builder.Entity<Translation>().HasData(new Translation { Key = "email.required", Value = "Campo email é obrigatório", LanguageId = 2 });
//builder.Entity<Translation>().HasData(new Translation { Key = "password.required", Value = "Campo palavra-passe é obrigatório", LanguageId = 2 });
//builder.Entity<Translation>().HasData(new Translation { Key = "confirmPassword.required", Value = "The confirmation password is required", LanguageId = 2 });
