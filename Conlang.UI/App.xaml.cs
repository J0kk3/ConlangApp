using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Conlang.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Conlang.UI.ViewModels;
using Conlang.UI.Services;
using System.Windows.Controls;
using System.Threading;
using Conlang.Application.Services;
using Conlang.Infrastructure.Repositories;
using Conlang.UI.UserControls;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception occurred: " + e.Exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;  // Prevents the program from terminating
        }

        public IServiceProvider ServiceProvider { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            {
                throw new Exception("Not running on an STA thread");
            }

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            //var mainWindow = new MainWindow();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            var navigationControl = ServiceProvider.GetRequiredService<NavigationControl>();
            mainWindow.navigationControlInstance.SetNavigationService(ServiceProvider.GetRequiredService<INavigationService>());

            mainWindow.Show();

            var loginPage = ServiceProvider.GetRequiredService<LoginPage>();
            Frame mainFrame = mainWindow.FindName("MainFrame") as Frame;

            loginPage.LoginSuccessful += OnLoginSuccessful;

            if (mainFrame != null)
            {
                mainFrame.Navigate(loginPage);
            }
            else
            {
                throw new Exception("MainFrame not found");
            }

            base.OnStartup(e);
        }

        void OnLoginSuccessful(object sender, EventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            // Force a layout update
            mainWindow.UpdateLayout();
            Frame mainFrame = mainWindow.FindName("MainFrame") as Frame;

            if (mainFrame != null)
            {
                var dashboardPage = ServiceProvider.GetRequiredService<DashboardPage>();
                mainFrame.Navigate(dashboardPage);
            }
            else
            {
                throw new Exception("MainFrame not found");
            }
        }

        void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ConlangDbContext>(options =>
                options.UseNpgsql(connectionString).EnableSensitiveDataLogging());

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<NavigationControl>();

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IConlangProjectRepository, ConlangProjectRepository>();

            services.AddTransient<LoginPage>();
            services.AddTransient<DashboardPage>();
            services.AddTransient<DictionaryPage>();
            services.AddTransient<SoundChangesPage>();
            services.AddTransient<FamilyTreePage>();
            services.AddTransient<IPAChart>();

            services.AddSingleton<INavigationService>(p =>
                new NavigationService(
                    (p.GetRequiredService<MainWindow>().FindName("MainFrame") as Frame)!, p));
        }
    }
}