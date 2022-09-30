using System.Reactive;
using ReactiveUI;
using StarDust.CasparCG.net.Connection;
using StarDust.CasparCG.net.Device;

namespace Avalonia.CasparCG.Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        private readonly ICasparDevice _casparDevice;
        private readonly FluentThemeManager _fluentThemeManager;

        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, Unit> GoBack => Router.NavigateBack;

        public ReactiveCommand<Unit, Unit> ToggleDarkThemeCommand { get; }


        public MainWindowViewModel(ICasparDevice casparDevice, FluentThemeManager fluentThemeManager)
        {
            _casparDevice = casparDevice;
            _fluentThemeManager = fluentThemeManager;
            _casparDevice.ConnectionStatusChanged += ConnectionStatusChanged;
            Router.Navigate.Execute(new NotConnectedViewModel(this));
            ToggleDarkThemeCommand = ReactiveCommand.Create(ToggleDarkMode);
        }


        private void ToggleDarkMode()
        {
            _fluentThemeManager.Switch(_fluentThemeManager.CurrentIndex != 1 ? 1 : 0);
        }

        private void ConnectionStatusChanged(object sender, ConnectionEventArgs e)
        {
            Router.Navigate.Execute(new NotConnectedViewModel(this));
        }

        public string Greeting => $"Welcome to Avalonia! {_casparDevice.IsConnected}";
    }
}
