using System.Collections.ObjectModel;
using Conlang.Core.Entities.Users;

namespace Conlang.UI.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Author> Authors { get; set; } = new ObservableCollection<Author>();
        public Author SelectedAuthor { get; set; }
        public string InputPassword { get; set; }
    }
}