using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime UploadDate { get; set; }
        [StringLength(68)]
        public string? Location { get; set; }
        [StringLength(256)]
        public string? Description { get; set; }
        public int? AlbumId { get; set; }

        public ICollection<PhotoPersonTag> PersonTags { get; set; }
        public ICollection<PhotoTextTag> TextTags { get; set; }
        public UserAccount Owner { get; set; }
        public Album? Album { get; set; }
        
        

    }
}
