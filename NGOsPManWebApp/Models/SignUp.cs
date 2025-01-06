using System.ComponentModel.DataAnnotations;

namespace NGOsPManWebApp.Models
{
    public class SignUp
    {
        [Key]
        public int Id { get; set; }
        public String? UserName {  get; set; }
        public String? Email {  get; set; }
        public String? Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public String? ConfirmPassword { get; set; }
    }
}
