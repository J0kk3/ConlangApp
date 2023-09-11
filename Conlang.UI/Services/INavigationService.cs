using Conlang.Application.Services;

namespace Conlang.UI.Services
{
    public interface INavigationService
    {
        void NavigateTo(string pageName);
        void NavigateToLoginPage(IAuthenticationService authService);
    }
}