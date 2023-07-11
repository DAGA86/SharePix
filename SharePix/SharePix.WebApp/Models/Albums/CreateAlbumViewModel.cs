using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.Albums
{
    public class CreateAlbumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int OwnerId { get; set; }
    }
}
