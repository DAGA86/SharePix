using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }       

    }
}
