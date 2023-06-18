namespace SharePix.Shared.Models
{
    public class Result<T>
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public T Object { get; set; }
    }
}
