using System.Collections.ObjectModel;
using System.ComponentModel;
using Conlang.Core.Entities.Users;

namespace Conlang.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Author> Authors { get; set; } = new ObservableCollection<Author>();
        public Author SelectedAuthor { get; set; }
        public string InputPassword { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}