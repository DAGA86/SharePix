using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Albums
{
    public class EditAlbumViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field.required")]
        [MaxLength(32, ErrorMessage = "album.name.maxLength")]
        [MinLength(1, ErrorMessage = "album.name.minLength")]
        public string Name { get; set; }
        [MaxLength(256, ErrorMessage = "album.description.maxLength")]
        public string? Description { get; set; }
        public IEnumerable<int> PhotoIds { get; set; }

    }
}
