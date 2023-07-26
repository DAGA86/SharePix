using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Photos
{
    public class EditPhotoViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(68, ErrorMessage = "photo.location.maxLength")]
        public string? Location { get; set; }
        [MaxLength(1000, ErrorMessage = "photo.description.maxLength")]
        public string? Description { get; set; }
        public int? AlbumId { get; set; }
        public IEnumerable<int>? textTagIds { get; set; }

    }
}
