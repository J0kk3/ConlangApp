using Conlang.Core.Entities.Users;
using Conlang.Infrastructure.Repositories;

namespace Conlang.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IAuthorRepository _authorRepository;

        public AuthenticationService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public bool Authenticate(string username, string password)
        {
            var author = _authorRepository.GetAuthorByName(username);
            if (author == null) return false;

            var hashedPassword = Author.CreateSaltedHash(password, author.Salt);

            return hashedPassword.SequenceEqual(author.Password);
        }

        public void Logout()
        {
            // If there's any local state or cache related to the current user, clear it here
        }

        public Author Register(string username, string password)
        {
            // Check for existing user
            var existingAuthor = _authorRepository.GetAuthorByName(username);
            if (existingAuthor != null)
            {
                // Author already exists
                return null;
            }

            // Generate a new salt
            var salt = Author.GenerateSalt();

            // Create salted hash using the generated salt
            var hashedPassword = Author.CreateSaltedHash(password, salt);

            // Create new author instance
            var newAuthor = new Author
            {
                Name = username,
                Password = hashedPassword,
                Salt = salt
            };

            _authorRepository.AddAuthor(newAuthor);
            _authorRepository.SaveChanges();  // Save changes to the database

            return newAuthor; // Return the newly created author
        }

        public bool DeleteAuthor(string username, string password)
        {
            var author = _authorRepository.GetAuthorByName(username);
            if (author == null)
                return false;

            var hashedPassword = Author.CreateSaltedHash(password, author.Salt);
            // Password doesn't match
            if (!hashedPassword.SequenceEqual(author.Password))
                    return false;

            _authorRepository.RemoveAuthor(author);
            return true;
        }
    }
}