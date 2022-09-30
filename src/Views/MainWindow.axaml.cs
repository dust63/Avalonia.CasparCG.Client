using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.CasparCG.Client.ViewModels;

namespace Avalonia.CasparCG.Client.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            //this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
              
    }
}