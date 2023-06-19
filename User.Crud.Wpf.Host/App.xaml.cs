using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Windows;
using User.Crud.Wpf.Utilities.Extensions;
using User.Crud.Wpf.View;
using User.Crud.Wpf.ViewModel;

namespace User.Crud.Wpf.Host
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public App()
        {
            _host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<MainPage>();
                    services.AddSingleton<UserViewModel>();
                    services.AddFormFactory<CreateUserForm>();
                    services.AddFormFactory<UpdateUserForm>();
                    services.AddFormFactory<ReadUserForm>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync(_cancellationTokenSource.Token);

            var startupForm = _host.Services.GetRequiredService<MainPage>();

            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync(_cancellationTokenSource.Token);

            base.OnExit(e);
        }
    }
}
