using System.ComponentModel.DataAnnotations;

namespace SharePix.WebApp.Models.UserAccounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [StringLength(320)]
        public string Email { get; set; }
    }
}
