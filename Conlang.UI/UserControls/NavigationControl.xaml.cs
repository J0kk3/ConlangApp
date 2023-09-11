using Conlang.Application.Services;
using Conlang.UI.Services;
using Conlang.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;

namespace Conlang.UI.UserControls
{
    /// <summary>
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : UserControl
    {
        INavigationService _navigationService;

        // Parameterless constructor mainly for design-time support
        public NavigationControl()
        {
            InitializeComponent();
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void SetActiveButton(string pageName)
        {
            ResetButtonColors();
            switch (pageName)
            {
                case "Dictionary":
                    DictionaryButton.Background = Brushes.LightBlue;
                    break;
                case "Sound Changes":
                    SoundChangesButton.Background = Brushes.LightBlue;
                    break;
                case "Family Tree":
                    FamilyTreeButton.Background = Brushes.LightBlue;
                    break;
                case "Dashboard":
                    DashboardButton.Background = Brushes.LightBlue;
                    break;
                case "Logout":
                    LogoutButton.Background = Brushes.LightBlue;
                    break;
            }
        }

        void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton("Dashboard");
            _navigationService.NavigateTo("Dashboard");
        }

        void DictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton("Dictionary");
            _navigationService.NavigateTo("Dictionary");
        }

        void SoundChangesButton_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton("Sound Changes");
            _navigationService.NavigateTo("Sound Changes");
        }

        void FamilyTreeButton_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton("Family Tree");
            _navigationService.NavigateTo("Family Tree");
        }

        void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            ResetButtonColors();
            var viewModel = mainWindow.DataContext as MainViewModel;

            if (viewModel != null)
            {
                viewModel.IsLoggedIn = false;

                var authService = ((App)System.Windows.Application.Current).ServiceProvider.GetRequiredService<IAuthenticationService>();
                authService.Logout();

                Frame mainFrame = mainWindow.FindName("MainFrame") as Frame;

                if (mainFrame != null)
                {
                    _navigationService.NavigateToLoginPage(authService);
                }
            }
        }

        void ResetButtonColors()
        {
            DictionaryButton.Background = Brushes.Transparent;
            SoundChangesButton.Background = Brushes.Transparent;
            FamilyTreeButton.Background = Brushes.Transparent;
            DashboardButton.Background = Brushes.Transparent;
            LogoutButton.Background = Brushes.Transparent;
        }
    }
}