using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira um nome")]
        [MaxLength(32)]
        [MinLength(3, ErrorMessage = "Min - 3 caracteres")]
        public string FirstName { get; set; }
        [StringLength(32)]
        public string LastName { get; set; }
        [StringLength(64)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Insira um email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(320)]
        public string Email { get; set; }
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
