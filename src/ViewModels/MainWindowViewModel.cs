using System.Reactive;
using Avalonia.Threading;
using ReactiveUI;
using StarDust.CasparCG.net.Connection;
using StarDust.CasparCG.net.Device;

namespace Avalonia.CasparCG.Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        public ICasparDevice CasparDevice { get; }
        private readonly FluentThemeManager _fluentThemeManager;

        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, Unit> GoBack => Router.NavigateBack;
        public ReactiveCommand<Unit, Unit> ToggleDarkThemeCommand { get; }

        public MainWindowViewModel(ICasparDevice casparDevice, FluentThemeManager fluentThemeManager)
        {
            CasparDevice = casparDevice;
            _fluentThemeManager = fluentThemeManager;
            CasparDevice.ConnectionStatusChanged += ConnectionStatusChanged;
            Router.Navigate.Execute(new NotConnectedViewModel(this, casparDevice));
            ToggleDarkThemeCommand = ReactiveCommand.Create(ToggleDarkMode);
        }

        private void ToggleDarkMode()
        {
            _fluentThemeManager.Switch(_fluentThemeManager.CurrentIndex != 1 ? 1 : 0);
        }

        private void ConnectionStatusChanged(object sender, ConnectionEventArgs e)
        { 
            if(e.Connected)
            {
                Dispatcher.UIThread.Post(() => Router.Navigate.Execute(new ConnectedViewModel(this, CasparDevice)));
                return;
            }

            Dispatcher.UIThread.Post(() =>
            Router.Navigate.Execute(new NotConnectedViewModel(this, CasparDevice)));
        }

        public string Greeting => $"Welcome to Avalonia! {CasparDevice.IsConnected}";
    }
}
