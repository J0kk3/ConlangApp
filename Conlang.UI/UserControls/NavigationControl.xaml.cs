using Conlang.Infrastructure.Data;
using Conlang.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Conlang.UI.UserControls
{
    /// <summary>
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : UserControl
    {
        readonly ConlangDbContext _context;

        // Parameterless constructor mainly for design-time support
        public NavigationControl()
        {
            InitializeComponent();
        }

        internal NavigationControl(ConlangDbContext context)
        {
            InitializeComponent();
            _context = context;
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
            var mainWindow = (MainWindow)Window.GetWindow(this);
            SetActiveButton("Dashboard");
            mainWindow.MainFrame.Navigate(new DictionaryPage());
        }

        void DictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            SetActiveButton("Dictionary");
            mainWindow.MainFrame.Navigate(new DictionaryPage());
        }

        void SoundChangesButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            SetActiveButton("Sound Changes");
            mainWindow.MainFrame.Navigate(new SoundChangesPage());
        }

        void FamilyTreeButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            SetActiveButton("Family Tree");
            mainWindow.MainFrame.Navigate(new FamilyTreePage());
        }

        void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            ResetButtonColors();
            //var authService = _serviceProvider.GetRequiredService<IAuthenticationService>();
            //authService.Logout();
            var viewModel = mainWindow.DataContext as MainViewModel;

            if (viewModel != null)
            {
                viewModel.IsLoggedIn = false;

                Frame mainFrame = mainWindow.FindName("MainFrame") as Frame;
                if (mainFrame != null)
                {
                    mainFrame.Navigate(new LoginPage(_context));
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