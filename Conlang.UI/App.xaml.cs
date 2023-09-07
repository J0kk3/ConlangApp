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

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
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

            var mainWindow = new MainWindow();
            mainWindow.Show();

            var loginPage = ServiceProvider.GetRequiredService<LoginPage>();
            loginPage.LoginSuccessful += OnLoginSuccessful;

            Frame mainFrame = mainWindow.FindName("MainFrame") as Frame;

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

            services.AddTransient<LoginPage>();
            services.AddTransient<DashboardPage>();
            services.AddTransient<DictionaryPage>();
            services.AddTransient<SoundChangesPage>();
            services.AddTransient<FamilyTreePage>();
        }
    }
}