using Conlang.UI.Services;
using System.Windows.Input;

namespace Conlang.UI.ViewModels
{
    public class NavigationViewModel
    {
        public ICommand NavigateToDashboardCommand { get; }
        public ICommand NavigateToDictionaryCommand { get; }
        public ICommand NavigateToSoundChangesCommand { get; }
        public ICommand NavigateToFamilyTreeCommand { get; }
        public ICommand NavigateToLogoutCommand { get; }
        readonly INavigationService _navigationService;

        public NavigationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToDashboardCommand = new RelayCommand(NavigateToDashboard);
            NavigateToDictionaryCommand = new RelayCommand(NavigateToDictionary);
            NavigateToSoundChangesCommand = new RelayCommand(NavigateToSoundChanges);
            NavigateToFamilyTreeCommand = new RelayCommand(NavigateToFamilyTree);
            NavigateToLogoutCommand = new RelayCommand(NavigateToLogout);
        }

        void NavigateToDashboard()
        {
            _navigationService.NavigateToDashboard();
        }

        void NavigateToDictionary()
        {
            _navigationService.NavigateToDictionary();
        }

        void NavigateToSoundChanges()
        {
            _navigationService.NavigateToSoundChanges();
        }

        void NavigateToFamilyTree()
        {
            _navigationService.NavigateToFamilyTree();
        }

        void NavigateToLogout()
        {
            _navigationService.Logout();
        }
    }
}