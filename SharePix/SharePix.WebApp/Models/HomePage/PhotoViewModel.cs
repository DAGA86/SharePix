using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.HomePage
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int? AlbumId { get; set; }
	}
}
