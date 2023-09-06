using Conlang.Infrastructure.Data;
using System;

namespace Conlang.UI.Services
{
    public interface INavigationService
    {
        void NavigateToDashboard();
        void NavigateToDictionary();
        void NavigateToSoundChanges();
        void NavigateToFamilyTree();
        void Logout();
    }

    public interface INavigationProvider
    {
        void Navigate(object content);
    }

    public class NavigationService : INavigationService
    {
        readonly MainWindow _mainWindow;
        readonly ConlangDbContext _context;
        readonly IServiceProvider _serviceProvider;

        public NavigationService(MainWindow mainWindow, ConlangDbContext context, IServiceProvider serviceProvider)
        {
            _mainWindow = mainWindow;
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public void NavigateToDashboard()
        {
            _mainWindow.MainFrame.Navigate(new DashboardPage(_serviceProvider));
        }

        public void NavigateToDictionary()
        {
            _mainWindow.MainFrame.Navigate(new DictionaryPage(_serviceProvider));
        }

        public void NavigateToSoundChanges()
        {
            _mainWindow.MainFrame.Navigate(new SoundChangesPage(_serviceProvider));
        }

        public void NavigateToFamilyTree()
        {
            _mainWindow.MainFrame.Navigate(new FamilyTreePage(_serviceProvider));
        }

        public void Logout()
        {
            _context.Dispose();
            _mainWindow.MainFrame.Navigate(new LoginPage(_context, _serviceProvider));
        }
    }

    // MainWindowNavigationProvider would be an implementation of INavigationProvider that uses the MainFrame from MainWindow.
    public class MainWindowNavigationProvider : INavigationProvider
    {
        readonly MainWindow _mainWindow;

        public MainWindowNavigationProvider(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void Navigate(object content)
        {
            _mainWindow.MainFrame.Navigate(content);
        }
    }
}