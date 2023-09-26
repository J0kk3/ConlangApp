using Conlang.Core.Entities;
using Conlang.Infrastructure.Repositories;
using Conlang.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        readonly IConlangProjectRepository _conlangProjectRepository;
        readonly IAuthorRepository _authorRepository;
        ObservableCollection<ConlangProject> _projects;

        public DashboardPage(IConlangProjectRepository conlangProjectRepository, IAuthorRepository authorRepository)
        {
            _conlangProjectRepository = conlangProjectRepository;
            _authorRepository = authorRepository;
            InitializeComponent();
            LoadConlangs();
        }

        void LoadConlangs()
        {
            try
            {
                if (DataContext is MainViewModel mainViewModel && mainViewModel.SelectedAuthor != null)
                {
                    var loggedInAuthor = mainViewModel.SelectedAuthor;

                    var projects = _conlangProjectRepository.GetConlangProjectsByAuthorId(loggedInAuthor.Id);
                    _projects = new ObservableCollection<ConlangProject>(projects);

                    ConlangsListView.ItemsSource = _projects;
                }
                else
                {
                    // Handle the case where no author is selected or DataContext is not correctly set
                }
            }
            catch
            {
                // Log or display the exception message
                throw new System.Exception("Error loading conlangs");
            }
        }
    }
}