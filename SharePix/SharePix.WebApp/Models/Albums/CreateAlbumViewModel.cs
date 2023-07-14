using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Albums
{
    public class CreateAlbumViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field.required")]
        [MaxLength(32, ErrorMessage = "createAlbum.name.maxLength")]
        [MinLength(1, ErrorMessage = "createAlbum.name.minLength")]
        public string Name { get; set; }
        [MaxLength(256, ErrorMessage = "createAlbum.description.maxLength")]
        public string? Description { get; set; }
        public int OwnerId { get; set; }
    }
}
