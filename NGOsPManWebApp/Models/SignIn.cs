using System.ComponentModel.DataAnnotations;

namespace NGOsPManWebApp.Models
{
    public class SignIn
    {
        [Key]
        public int Id { get; set; }

        public string? UserName { get; set; }

        
        public string? Password { get; set; }
    }
}
