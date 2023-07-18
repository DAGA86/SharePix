using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Photos
{
    public class EditPhotoViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(68, ErrorMessage = "uploadPhoto.location.maxLength")]
        public string? Location { get; set; }
        [MaxLength(1000, ErrorMessage = "uploadPhoto.description.maxLength")]
        public string? Description { get; set; }
    }
}
