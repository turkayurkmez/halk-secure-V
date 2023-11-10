using System.ComponentModel.DataAnnotations;

namespace AuthZFlowMVC.Models
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
