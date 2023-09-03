using Conlang.Core.Entities.Users;
using Conlang.Infrastructure.Data;
using Conlang.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Conlang.UI
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ConlangDbContext _dbContext;
        public MainViewModel ViewModel { get; set; }

        public MainWindow(ConlangDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;

            ViewModel = new MainViewModel
            {
                Authors = new ObservableCollection<Author>(_dbContext.Authors.ToList())
            };

            this.DataContext = ViewModel;
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
            // Get username and password from TextBox and PasswordBox
            var username = UserNameTextBox.Text;
            var password = UserPasswordBox.Password;

            // Check for existing user
            var existingAuthor = _dbContext.Authors.FirstOrDefault(a => a.Name == username);
            if (existingAuthor != null)
            {
                MessageBox.Show("Author already exists!");
                return;
            }

            // Generate a new salt
            var salt = Author.GenerateSalt();

            // Create salted hash using the generated salt
            var hashedPassword = Author.CreateSaltedHash(password, salt);

            // Create new author instance
            var newAuthor = new Author
            {
                Name = username,
                Password = hashedPassword,
                Salt = salt
            };

            // Add new author to ViewModel's authors list
            ViewModel.Authors.Add(newAuthor);

            // Save the author to the database
            _dbContext.Authors.Add(newAuthor);
            _dbContext.SaveChanges();

            // Navigate to the new window
            WorkspaceWindow workspace = new WorkspaceWindow();
            workspace.Show();
            this.Close();
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

                e.Handled = true; // Important! Suppress further handling.
            }
        }

        void OnAuthorLoginClicked(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedAuthor == null)
            {
                MessageBox.Show("Please select an author.");
                return;
            }

            var hashedInputPassword = Author.CreateSaltedHash(ViewModel.InputPassword, ViewModel.SelectedAuthor.Salt);

            if (hashedInputPassword == ViewModel.SelectedAuthor.Password)
            {
                // Login successful.
                MessageBox.Show("Logged in successfully!");

                // Navigate to the main application window or workspace
                WorkspaceWindow workspace = new WorkspaceWindow();
                workspace.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.");
            }
        }

        void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            var vm = (MainViewModel)this.DataContext;
            vm.InputPassword = passwordBox.Password;
        }

        void DeleteAuthorClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedAuthor == null) return;

            var hashedInputPassword = Author.CreateSaltedHash(ViewModel.InputPassword, ViewModel.SelectedAuthor.Salt);

            if (hashedInputPassword == ViewModel.SelectedAuthor.Password)
            {
                // Delete author logic
                _dbContext.Authors.Remove(ViewModel.SelectedAuthor);
                _dbContext.SaveChanges();
                ViewModel.Authors.Remove(ViewModel.SelectedAuthor);
            }
            else
            {
                MessageBox.Show("Incorrect password. Cannot delete author.");
            }
        }
        
        void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
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