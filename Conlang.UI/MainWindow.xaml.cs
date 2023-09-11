using Conlang.UI.Services;
using Conlang.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Conlang.UI.UserControls;
using Conlang.Application.Services;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the DataContext for the main window
            this.DataContext = ((App)System.Windows.Application.Current).ServiceProvider.GetService<MainViewModel>();
        }
    }
}