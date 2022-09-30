using System;
using ReactiveUI;

namespace Avalonia.CasparCG.Client
{
    public class AppViewLocator : IViewLocator
    {
        IViewFor? IViewLocator.ResolveView<T>(T viewModel, string? contract)
        {
            var name = viewModel!.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (IViewFor)Activator.CreateInstance(type)!;
            }
            return null;
        }


    }
}
