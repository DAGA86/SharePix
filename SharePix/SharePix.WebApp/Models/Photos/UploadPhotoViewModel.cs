namespace SharePix.WebApp.Models.Photos
{
    public class UploadPhotoViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }  
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int? OwnerId { get; set; }

    }
}
