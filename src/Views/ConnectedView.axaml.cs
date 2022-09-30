
using Avalonia.CasparCG.Client.ViewModels;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace Avalonia.CasparCG.Client.Views
{
    public partial class ConnectedView : ReactiveUI.ReactiveUserControl<ConnectedViewModel>
    {
        public ConnectedView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}