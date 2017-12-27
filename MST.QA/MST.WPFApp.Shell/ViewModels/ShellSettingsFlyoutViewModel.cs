using MahApps.Metro;
using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.Infrastructure.Events;
using MST.WPFApp.Infrastructure.Interfaces;
using MST.WPFApp.Shell.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace MST.WPFApp.Shell.ViewModels
{
    public class ShellSettingsFlyoutViewModel : ViewModelBase
    {
        private IGlobalConfigService _globalConfigService;

        public ShellSettingsFlyoutViewModel(IGlobalConfigService globalConfigService)
        {
            _globalConfigService = globalConfigService;

            this.ApplicationThemes = ThemeManager.AppThemes
                .Select(a => new ApplicationTheme() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                .ToList();

            this.AccentColors = ThemeManager.Accents
                                .Select(a => new AccentColor() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                .ToList();
        }

        private IList<ApplicationTheme> applicationsThemes;

        public IList<ApplicationTheme> ApplicationThemes
        {
            get { return applicationsThemes; }
            set { this.SetProperty<IList<ApplicationTheme>>(ref this.applicationsThemes, value); }
        }

        private IList<AccentColor> accentColors;

        public IList<AccentColor> AccentColors
        {
            get { return accentColors; }
            set { this.SetProperty<IList<AccentColor>>(ref this.accentColors, value); }
        }

        private ApplicationTheme selectedTheme;

        public ApplicationTheme SelectedTheme
        {
            get { return selectedTheme; }
            set
            {
                if (this.SetProperty<ApplicationTheme>(ref this.selectedTheme, value))
                {
                    var theme = ThemeManager.DetectAppStyle(Application.Current);
                    var appTheme = ThemeManager.GetAppTheme(value.Name);
                    ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);

                    _globalConfigService.Update(AppSettingsParam.AppTheme, appTheme.Name);

                    EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(String.Format("Theme changed to {0}", value.Name));
                }
            }
        }

        private AccentColor selectedAccentColor;

        public AccentColor SelectedAccentColor
        {
            get { return selectedAccentColor; }
            set
            {
                if (this.SetProperty<AccentColor>(ref this.selectedAccentColor, value))
                {
                    var theme = ThemeManager.DetectAppStyle(Application.Current);
                    var accent = ThemeManager.GetAccent(value.Name);
                    ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);

                    EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(String.Format("Accent color changed to {0}", value.Name));
                }
            }
        }
    }
}
