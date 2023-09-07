using Conlang.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

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
            this.DataContext = ((App)Application.Current).ServiceProvider.GetService<MainViewModel>();
        }
    }
}