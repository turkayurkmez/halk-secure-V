using System.ComponentModel.DataAnnotations;

namespace AuthZFlowMVC.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adını boş bırakmayın!")]
        [MinLength(3, ErrorMessage = "en az üç karakter")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
