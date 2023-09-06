using Conlang.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            var navigationService = _serviceProvider.GetRequiredService<Services.INavigationService>();
            navigationControlInstance.DataContext = new NavigationViewModel(navigationService);
        }
    }
}