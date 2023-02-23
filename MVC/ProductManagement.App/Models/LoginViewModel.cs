using System.ComponentModel.DataAnnotations;

namespace ProductManagement.App.Models
{
    public class LoginViewModel
    {
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }
        [Required]
       
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
