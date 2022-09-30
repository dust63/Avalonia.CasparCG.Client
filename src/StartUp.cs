
using System;
using Avalonia;
using Avalonia.CasparCG.Client.ViewModels;
using Avalonia.CasparCG.Client.Views;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using StarDust.CasparCG.net.AmcpProtocol;
using StarDust.CasparCG.net.Connection;
using StarDust.CasparCG.net.Device;

namespace Avalonia.CasparCG.Client;


public class StartUp
{

    public static IServiceProvider CreateHosting()
    {
        var host = Host
          .CreateDefaultBuilder()
          .ConfigureServices(services =>
          {
              services.UseMicrosoftDependencyResolver();
              var resolver = Locator.CurrentMutable;
              resolver.InitializeSplat();
              resolver.InitializeReactiveUI();

              // Configure our local services and access the host configuration
              ConfigureServices(services);
          })
          .ConfigureLogging(loggingBuilder =>
          {
              /*
              //remove loggers incompatible with UWP
              {
                var eventLoggers = loggingBuilder.Services
                  .Where(l => l.ImplementationType == typeof(EventLogLoggerProvider))
                  .ToList();

                foreach (var el in eventLoggers)
                  loggingBuilder.Services.Remove(el);
              }
              */

              //loggingBuilder.AddSplat();
          })
          .UseEnvironment(Environments.Development)
          .Build();

        // Since MS DI container is a different type,
        // we need to re-register the built container with Splat again
        var container = host.Services;
        container.UseMicrosoftDependencyResolver();
        return container;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        AddCasparCg(services);
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<FluentThemeManager>();
    }

    public static void AddCasparCg(IServiceCollection services)
    {
        services.AddTransient<IServerConnection, ServerConnection>();
        services.AddSingleton<IAMCPTcpParser, AmcpTCPParser>();
        services.AddSingleton<IDataParser, CasparCGDataParser>();
        services.AddSingleton<IAMCPProtocolParser, AMCPProtocolParser>();
        services.AddTransient<ICasparDevice, CasparDevice>();
    }
}