using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using musicApp_clean.Infrastructure.EntityFramework.Model;
using musicApp_clean.UI.Services.Implementation;
using musicApp_clean.UI.Services.Interface;
using musicApp_clean.UI.View;
using musicApp_clean.UI.ViewModel;
using System.Windows;

namespace musicApp_clean.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(provider => new NavigationView
            {
                DataContext = provider.GetRequiredService<NavigationViewModel>()
            });
            services.AddSingleton<NavigationViewModel>();
            services.AddSingleton<MusicsViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<MusicControlViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IMusicService, MusicService>();
            services.AddSingleton<Func<Type, ObservableObject>>(serviceProvider => viewModelType => (ObservableObject)serviceProvider.GetRequiredService(viewModelType));
            services.AddHttpClient();
            services.AddDbContextFactory<MusicsDbContext>();

            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<NavigationView>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
