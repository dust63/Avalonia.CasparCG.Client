using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Avalonia.CasparCG.Client.ViewModels;

namespace Avalonia.CasparCG.Client.Views
{
    public partial class NotConnectedView : ReactiveUserControl<NotConnectedViewModel>
    {
        public NotConnectedView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
