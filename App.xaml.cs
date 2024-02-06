using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Context;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ServiceCollection _collection;
        IServiceProvider _serviceProvide;

        public App()
        {
            _collection = new ServiceCollection();
            _collection.AddDbContext<AppDbContext>(opt => {
                opt.UseSqlServer("server=DESKTOP-J4B83I5\\SQLEXPRESS;database=MyApp; integrated security = true; TrustServerCertificate=true");
            });
            _collection.AddSingleton<MainWindow>();
            _serviceProvide = _collection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var appDbContext = _serviceProvide.GetService<AppDbContext>()!;
            appDbContext.Database.EnsureDeleted();
            appDbContext.Database.EnsureCreated();

            MainWindow mainWindow = _serviceProvide.GetService<MainWindow>()!;
            mainWindow.Show();  
        }
    }
}
