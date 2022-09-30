using System;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace Avalonia.CasparCG.Client.ViewModels
{
    public class NotConnectedViewModel : ViewModelBase, IRoutableViewModel
    {
        public NotConnectedViewModel(IScreen screen) => HostScreen = screen;    

        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }
    }
}
