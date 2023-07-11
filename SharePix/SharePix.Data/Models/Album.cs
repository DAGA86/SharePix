using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [StringLength(32)]
        public string Name { get; set; }
        [StringLength(256)]
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int OwnerId { get; set; }

        public UserAccount Owner { get; set; }
        public ICollection<Photo> PhotoAlbuns { get; set; }
    }
}
