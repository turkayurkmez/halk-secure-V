namespace JWTAuthWithREST
{
    public class UserService
    {
        private List<User> users = new()
        {
            new(){ Id=1, Name="türkay", Email="t@u.com", Password="123456", Role="Admin"},
            new(){ Id=2, Name="aykut", Email="a@a.com", Password="123456", Role="Client"},
            new(){ Id=3, Name="erhan", Email="e@a.com", Password="123456", Role="Editor"},

        };
        public User ValidateUser(string email, string password)
        {
            return users.SingleOrDefault(user => user.Email == email && user.Password == password);
        }
    }
}
