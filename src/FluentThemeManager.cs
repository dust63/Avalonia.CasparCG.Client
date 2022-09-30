using System;
using Avalonia;
using Avalonia.Themes.Fluent;


namespace Avalonia.CasparCG.Client
{
    public class FluentThemeManager
    {
        private static readonly Uri BaseUri = new("avares://Avalonia.ThemeManager/Styles");

        private static readonly FluentTheme Fluent = new(BaseUri)
        {
            Mode = FluentThemeMode.Light
        };

        public int CurrentIndex { get; private set; }

        public void Switch(int index)
        {
            if (Application.Current is null)
            {
                return;
            }

            
            switch (index)
            {
                // Fluent Light
                case 0:
                    {
                        if (Fluent.Mode != FluentThemeMode.Light)
                        {
                            Fluent.Mode = FluentThemeMode.Light;
                        }
                        Application.Current.Styles[0] = Fluent;
                        break;
                    }
                // Fluent Dark
                case 1:
                    {
                        if (Fluent.Mode != FluentThemeMode.Dark)
                        {
                            Fluent.Mode = FluentThemeMode.Dark;
                        }
                        Application.Current.Styles[0] = Fluent;
                        break;
                    }
            }
            CurrentIndex = index;
        }

        public void Initialize(Application application)
        {
            application.Styles.Insert(0, Fluent);
        }
    }

}