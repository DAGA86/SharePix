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


    }
}

//TODO delete
public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer("Server=LAPTOP-SONIA;Database=SharePix;User Id=sa;Password=developer;MultipleActiveResultSets=true");

        return new DatabaseContext(optionsBuilder.Options);
    }
}
