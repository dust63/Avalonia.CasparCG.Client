using System;
using System.Reactive;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using ReactiveUI;
using StarDust.CasparCG.net.Device;

namespace Avalonia.CasparCG.Client.ViewModels
{
    public class NotConnectedViewModel : ViewModelBase, IRoutableViewModel
    {
        private readonly ICasparDevice _casparDevice;

        public ReactiveCommand<Unit, Unit> ConnectCommand { get; private set; }
        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }

        public NotConnectedViewModel(IScreen screen, ICasparDevice casparDevice)
        {
            HostScreen = screen;
            _casparDevice = casparDevice;
            ConnectCommand = ReactiveCommand.Create(ConnectCasparCg);
        }

        private void ConnectCasparCg()
        {
             Dispatcher.UIThread.Post(() =>
            _casparDevice.Connect("localhost"));
        }




    }
}
