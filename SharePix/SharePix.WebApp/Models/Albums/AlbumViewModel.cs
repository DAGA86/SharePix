using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Albums
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field.required")]
        [MaxLength(32, ErrorMessage = "album.name.maxLength")]
        [MinLength(1, ErrorMessage = "album.name.minLength")]
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Description { get; set; }
        public List<AlbumPhotoViewModel> Photos { get; set; }
    }   

    public class AlbumPhotoViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? UploadDate { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
    }
}
