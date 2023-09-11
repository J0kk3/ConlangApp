using System.Windows.Controls;
using System;
using Microsoft.Extensions.DependencyInjection;
using Conlang.Application.Services;

namespace Conlang.UI.Services
{
    public class NavigationService : INavigationService
    {
        readonly Frame _mainFrame;
        readonly IServiceProvider _serviceProvider;

        public NavigationService(Frame mainFrame, IServiceProvider serviceProvider)
        {
            _mainFrame = mainFrame;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo(string pageName)
        {
            switch (pageName)
            {
                case "Dictionary":
                    _mainFrame.Navigate(_serviceProvider.GetRequiredService<DictionaryPage>());
                    break;
                case "Sound Changes":
                    _mainFrame.Navigate(_serviceProvider.GetRequiredService<SoundChangesPage>());
                    break;
                case "Family Tree":
                    _mainFrame.Navigate(_serviceProvider.GetRequiredService<FamilyTreePage>());
                    break;
                case "Dashboard":
                    _mainFrame.Navigate(_serviceProvider.GetRequiredService<DashboardPage>());
                    break;
                default:
                    throw new ArgumentException("Invalid page name", nameof(pageName));
            }
        }

        public void NavigateToLoginPage(IAuthenticationService authService)
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
            _mainFrame.Navigate(loginPage);
        }
    }
}