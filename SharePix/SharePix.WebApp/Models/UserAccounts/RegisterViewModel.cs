using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field.required")]
        [MaxLength(32, ErrorMessage = "register.firstName.maxLength")]
        [MinLength(3, ErrorMessage = "register.firstName.minLength")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "field.required")]
        [MaxLength(32, ErrorMessage = "register.lastName.maxLength")]
        [MinLength(3, ErrorMessage = "register.lastName.minLength")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "field.required")]
        [MaxLength(64, ErrorMessage = "register.username.maxLength")]
        [MinLength(3, ErrorMessage = "register.username.minLength")]
        public string Username { get; set; }
        [Required(ErrorMessage = "field.required")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "email.regularExpression")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(320, ErrorMessage = "email.maxLength")]
        public string Email { get; set; }
        [Required(ErrorMessage = "field.required")]  
        [DataType(DataType.Password)]
        [MaxLength(128, ErrorMessage = "password.maxLength")]
        [MinLength(5, ErrorMessage = "password.minLength")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$", ErrorMessage = "password.regularExpression")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "field.required")]
        [Compare("Password", ErrorMessage = "confirmPassword.compare")]
        public string ConfirmPassword { get; set; }
        
    }
}
