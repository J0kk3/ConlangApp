using System.Collections.ObjectModel;
using System.ComponentModel;
using Conlang.Core.Entities.Users;
using Conlang.Infrastructure.Repositories;

namespace Conlang.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Author> Authors { get; set; } = new ObservableCollection<Author>();
        public Author SelectedAuthor { get; set; }
        public string InputPassword { get; set; }

        readonly IAuthorRepository _authorRepository;

        bool _isLoggedIn = false;

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public MainViewModel(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void LoadAuthors()
        {
            var authorsFromDb = _authorRepository.GetAllAuthors();
            Authors.Clear();
            foreach (var author in authorsFromDb)
            {
                Authors.Add(author);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}