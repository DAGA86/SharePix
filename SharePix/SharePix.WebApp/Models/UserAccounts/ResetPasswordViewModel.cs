using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "field.required")]
        [DataType(DataType.Password)]
        [MaxLength(128, ErrorMessage = "password.maxLength")]
        [MinLength(5, ErrorMessage = "password.minLength")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$", ErrorMessage = "password.regularExpression")]
        public string Password { get; set; }       

    }
}
