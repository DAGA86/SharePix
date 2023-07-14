using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Photos
{
    public class UploadPhotoViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(68, ErrorMessage = "uploadPhoto.location.maxLength")]
        public string? Location { get; set; }
        [MaxLength(256, ErrorMessage = "uploadPhoto.description.maxLength")]
        public string? Description { get; set; }
        public int? OwnerId { get; set; }

    }
}
