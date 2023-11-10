using System.ComponentModel.DataAnnotations;

namespace AuthZFlowMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }

    }

    public class UserService
    {
        private List<User> users;
        public UserService()
        {
            users = new List<User>
            {
                 new(){ Id = 1, Name="Türkay", UserName="turkayurkmez", Password="123456", Role="admin"},
                 new(){ Id = 2, Name="Didem", UserName="didems", Password="123456", Role="editor"},
                 new(){ Id = 3, Name="Ebru", UserName="ebruseher", Password="123456", Role="client"},
            };
        }
        public User? ValidateUser(string userName, string password)
        {
            return users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
