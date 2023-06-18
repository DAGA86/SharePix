using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(320)]
        public string? UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
