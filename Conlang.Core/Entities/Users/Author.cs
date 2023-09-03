using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Conlang.Core.Entities.Users
{
    public class Author : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public List<ConlangProject> ConlangProjects { get; set; } = new List<ConlangProject>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static string CreateSaltedHash(string password, string salt)
        {
            // Hash the password with the provided salt
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32]; // 256 bits
            RandomNumberGenerator.Fill(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}