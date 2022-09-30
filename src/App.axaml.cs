using System;
using Avalonia;
using Avalonia.CasparCG.Client.ViewModels;
using Avalonia.CasparCG.Client.Views;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Splat;


namespace Avalonia.CasparCG.Client
{
    public partial class App : Application
    {
        public IServiceProvider? Container { get; private set; }
        public override void Initialize()
        {
            Container = StartUp.CreateHosting();
            AvaloniaXamlLoader.Load(this);
            //var thm = Container.GetRequiredService<FluentThemeManager>();
            //thm.Initialize(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = Locator.Current.GetService<MainWindowViewModel>(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }

}