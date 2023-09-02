using Conlang.Core.Entities.Users;
using Conlang.Infrastructure.Data;
using Conlang.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Conlang.UI
{
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

            ViewModel = new MainViewModel();
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

            // Create salted hash
            var hashedPassword = Author.CreateSaltedHash(password, out var salt);

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