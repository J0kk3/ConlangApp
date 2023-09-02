using System.Collections.ObjectModel;
using Conlang.Core.Entities.Users;

namespace Conlang.UI.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Author> Authors { get; set; } = new ObservableCollection<Author>();

        // Any other properties or commands required for the main window's UI.
    }
}