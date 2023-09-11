using Conlang.Core.Entities.Users;
using Conlang.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Conlang.Application.Services;
using Conlang.UI.Services;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class LoginPage : Page
    {
        public MainViewModel ViewModel { get; set; }
        readonly IAuthenticationService _authenticationService;
        readonly INavigationService _navigationService;

        public LoginPage(IAuthenticationService authenticationService, INavigationService navigationService, MainViewModel viewModel)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            ViewModel = viewModel;
            InitializeComponent();

            ViewModel.LoadAuthors();
            this.DataContext = ViewModel;
        }

        public event EventHandler LoginSuccessful;

        protected virtual void OnLoginSuccessful()
        {
            ViewModel.IsLoggedIn = true;
            _navigationService.NavigateTo("Dashboard");
            LoginSuccessful?.Invoke(this, EventArgs.Empty);
        }

        T FindParentOfType<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            if (parent == null) return null;

            if (parent is T tParent)
            {
                return tParent;
            }
            else
            {
                return FindParentOfType<T>(parent);
            }
        }

        void OnCreateAuthorClicked(object sender, RoutedEventArgs e)
        {
            var username = UserNameTextBox.Text;
            var password = UserPasswordBox.Password;

            var newAuthor = _authenticationService.Register(username, password);

            if (newAuthor != null)
            {
                ViewModel.Authors.Add(newAuthor);
                OnLoginSuccessful();
            }
            else
            {
                MessageBox.Show("Author already exists!");
            }
        }

        void OnAuthorLoginClicked(object sender, RoutedEventArgs e)
        {
            var username = ViewModel.SelectedAuthor?.Name;
            var password = ViewModel.InputPassword;

            if (_authenticationService.Authenticate(username, password))
            {
                MessageBox.Show("Logged in successfully!");
                OnLoginSuccessful();
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.");
            }
        }

        void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            ViewModel.InputPassword = passwordBox.Password;
        }

        void DeleteAuthorClick(object sender, RoutedEventArgs e)
        {
            var username = ViewModel.SelectedAuthor?.Name;
            var password = ViewModel.InputPassword;

            if (_authenticationService.DeleteAuthor(username, password))
            {
                ViewModel.Authors.Remove(ViewModel.SelectedAuthor);
                MessageBox.Show("Author deleted successfully!");
            }
            else
            {
                MessageBox.Show("Incorrect password. Cannot delete author.");
            }
        }

        void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0 && e.RemovedItems[0] is Author previousAuthor)
            {
                previousAuthor.IsSelected = false;
            }

            if (e.AddedItems.Count > 0 && e.AddedItems[0] is Author newAuthor)
            {
                newAuthor.IsSelected = true;
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (e.Key == Key.Escape && ViewModel.SelectedAuthor != null)
            {
                ViewModel.SelectedAuthor.IsSelected = false;
                ViewModel.SelectedAuthor = null;

                // Explicitly clear the ListView's selection
                var authorsListView = this.FindName("AuthorsListView") as ListView;
                if (authorsListView != null)
                {
                    authorsListView.SelectedIndex = -1;
                }

                e.Handled = true;
            }
        }

        void LoginPage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Check if the clicked item is part of the ListView
            var item = ItemsControl.ContainerFromElement(AuthorsListView, e.OriginalSource as DependencyObject) as ListViewItem;
            if (item == null)
            {
                // Deselect the current item
                AuthorsListView.SelectedIndex = -1;

                if (ViewModel.SelectedAuthor != null)
                {
                    ViewModel.SelectedAuthor.IsSelected = false;
                    ViewModel.SelectedAuthor = null;
                }
            }
        }

        void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Hide the placeholder (TextBlock) when the TextBox gets focus.
            FindParentOfType<Grid>((TextBox)sender).Children.OfType<TextBlock>().First().Visibility = Visibility.Collapsed;
        }

        void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder (TextBlock) if the TextBox loses focus and is empty.
            var textBox = (TextBox)sender;
            var placeholder = FindParentOfType<Grid>(textBox).Children.OfType<TextBlock>().First();
            placeholder.Visibility = string.IsNullOrEmpty(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Hide the placeholder (TextBlock) when the PasswordBox gets focus.
            FindParentOfType<Grid>((PasswordBox)sender).Children.OfType<TextBlock>().First().Visibility = Visibility.Collapsed;
        }

        void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder (TextBlock) if the PasswordBox loses focus and is empty.
            var passwordBox = (PasswordBox)sender;
            var placeholder = FindParentOfType<Grid>(passwordBox).Children.OfType<TextBlock>().First();
            placeholder.Visibility = string.IsNullOrEmpty(passwordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}