using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AuthZFlowMVC.Models
{
    public class PasswordHasher
    {
        public string GetHashedPassword(string password)
        {
            byte[] salt = new byte[16];
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100000, 32));
            return hashed;
        }
    }
}
