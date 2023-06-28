using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "field.required")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "email.regularExpression")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(320, ErrorMessage = "email.maxLength")]
        public string Email { get; set; }

        public Guid RecoveryToken { get; set; }
    }
}
