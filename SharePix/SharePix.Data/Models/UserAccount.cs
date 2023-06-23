using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        [StringLength(32)]
        public string? FirstName { get; set; }
        [StringLength(32)]
        public string? LastName { get; set; }
        [StringLength(64)]
        public string? Username { get; set; }
        [StringLength(320)]
        public string Email { get; set; }
        [StringLength(128)]
        public string? PasswordHash { get; set; }
        public DateTime? RegisterDate { get; set; }       
        public bool IsActive { get; set; }
        public Guid? RecoveryToken { get; set; }



        public ICollection<Friend> FriendsAddedThis { get; set; }
        public ICollection<Friend> FriendsAddedByThis { get; set; }
        public ICollection<PhotoPersonTag> PhotoPersonTags { get; set; }
        public ICollection<Photo> OwnedPhotos { get; set; }
        public ICollection<Album> OwnedAlbuns { get; set; }
        public ICollection<UserGroup> UserGroups { get; set;}
        public ICollection<Group> Groups { get; set;}

    }

}
