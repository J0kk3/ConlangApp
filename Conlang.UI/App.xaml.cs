using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Conlang.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

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
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // TestDatabaseConnection();

            base.OnStartup(e);
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

            // Register other necessary services
            // services.AddTransient<YourRepository>();
        }

        // void TestDatabaseConnection()
        // {
        //     using var scope = ServiceProvider.CreateScope();
        //     var dbContext = scope.ServiceProvider.GetRequiredService<ConlangDbContext>();

        //     // Try fetching data or any other operation
        //     var anyWordsExist = dbContext.Words.Any();

        //     if (anyWordsExist)
        //     {
        //         MessageBox.Show("Successfully connected to the database and found words.");
        //     }
        //     else
        //     {
        //         MessageBox.Show("Successfully connected to the database but no words found.");
        //     }
        // }
    }
}