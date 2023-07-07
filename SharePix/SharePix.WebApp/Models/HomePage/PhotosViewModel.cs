using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.HomePage
{
    public class PhotosViewModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int? AlbumId { get; set; }

		public Photos.UploadPhotoViewModel[] UploadPhoto { get; set; } = new Photos.UploadPhotoViewModel[0];
	}
}
