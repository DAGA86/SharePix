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
            builder.Entity<Friend>().HasKey(x => new { x.UserAccountId, x.FriendAccountId});

            builder.Entity<UserAccount>().HasMany(x => x.PhotoPersonTags).WithOne(x => x.Person);
            builder.Entity<Photo>().HasMany(x => x.PersonTags).WithOne(x => x.Photo);
            builder.Entity<PhotoPersonTag>().HasKey(x => new { x.PhotoId, x.PersonId});

            builder.Entity<Photo>().HasMany(x => x.TextTags).WithOne(x => x.Photo);
            builder.Entity<TextTag>().HasMany(x => x.PhotoTextTags).WithOne(x => x.Tag);
            builder.Entity<PhotoTextTag>().HasKey(x => new { x.PhotoId, x.TagId});

            builder.Entity<Group>().HasMany(x => x.UserGroups).WithOne(x => x.Group);
            builder.Entity<UserAccount>().HasMany(x => x.UserGroups).WithOne(x => x.User);
            builder.Entity<UserGroup>().HasKey(x => new { x.GroupId, x.UserId});

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

            builder.Entity<Translation>().HasData(new Translation { Key = "register.title", Value = "Registar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "login.title", Value = "Entrar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.login", Value = "Entrar", LanguageId = 2 });
            builder.Entity<Translation>().HasData(new Translation { Key = "general.button.create", Value = "Criar", LanguageId = 2 });
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


            base.OnModelCreating(builder);
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Photo> Photos { get; set; }        
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PhotoPersonTag> PhotoPersonTags { get; set; }
        public DbSet<PhotoTextTag> PhotoTextTags { get; set;}
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
