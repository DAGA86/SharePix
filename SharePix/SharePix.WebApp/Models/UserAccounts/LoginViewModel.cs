using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "field.required")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "field.required")]
        [DataType(DataType.Password)]
        [MaxLength(128, ErrorMessage = "password.maxLength")]
        [MinLength(5, ErrorMessage = "password.minLength")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$", ErrorMessage = "password.regularExpression")]
        public string Password { get; set; }
    }
}
