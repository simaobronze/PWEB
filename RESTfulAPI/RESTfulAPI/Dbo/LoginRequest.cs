using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.Dbo
{
    public class LoginRequest
    {
        [Required]
        public  required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
