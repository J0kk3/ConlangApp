using Conlang.Infrastructure.Data;
using Conlang.UI.UserControls;
using Conlang.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        readonly IServiceProvider _serviceProvider;
        public DashboardPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            //var navigationViewModel = _serviceProvider.GetRequiredService<NavigationViewModel>();
            //NavigationControl.DataContext = navigationViewModel;
        }
    }
}