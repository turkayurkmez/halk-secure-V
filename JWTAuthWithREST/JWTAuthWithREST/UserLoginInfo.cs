using System.ComponentModel.DataAnnotations;

namespace JWTAuthWithREST
{
    public class UserLoginInfo
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
