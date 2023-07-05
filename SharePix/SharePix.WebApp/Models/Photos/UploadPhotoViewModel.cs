using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Photos
{
    public class UploadPhotoViewModel
    {
        public DateTime? Date { get; set; }  
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int OwnerId { get; set; }

    }
}
