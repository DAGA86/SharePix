using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Insira a senha novamente")]
        [Compare("PasswordHash", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }      
    }
}
