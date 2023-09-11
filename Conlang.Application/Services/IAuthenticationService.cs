using Conlang.Core.Entities.Users;

namespace Conlang.Application.Services
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
        void Logout();
        Author Register(string username, string password);
        bool DeleteAuthor(string username, string password);
    }
}