using System.Security.Cryptography;
using System.Text;

namespace Conlang.Core.Entities.Users
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public List<ConlangProject> ConlangProjects { get; set; } = new List<ConlangProject>();

        public static string CreateSaltedHash(string password, out string salt)
        {
            // Create a random salt
            byte[] saltBytes = new byte[32]; // 256 bits
            RandomNumberGenerator.Fill(saltBytes);  // <-- Updated line
            salt = Convert.ToBase64String(saltBytes);

            // Hash the password with the salt
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}