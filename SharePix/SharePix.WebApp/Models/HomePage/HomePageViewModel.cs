namespace SharePix.WebApp.Models.HomePage
{
    //[Table("Photo")]
    public class HomePageViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int? AlbumId { get; set; }
        public string? AlbumName { get; set; }
    }
}
