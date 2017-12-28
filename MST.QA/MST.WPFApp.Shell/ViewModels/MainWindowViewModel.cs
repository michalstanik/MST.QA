using MahApps.Metro;
using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.Infrastructure.Events;
using MST.WPFApp.Infrastructure.Interfaces;
using System.Windows;
using System;
using Prism.Logging;
using Microsoft.Practices.Unity;

namespace MST.WPFApp.Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IGlobalConfigService _globalConfigService;

        public MainWindowViewModel(IGlobalConfigService globalConfigService)
        {
            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);

            _globalConfigService = globalConfigService;
            GetSavedSettings();

            Container.Resolve<ILoggerFacade>().Log("MainViewModel created", Category.Info, Priority.None);

        }

        private string statusBarMessage;

        public string StatusBarMessage
        {
            get { return statusBarMessage; }
            set { this.SetProperty<string>(ref this.statusBarMessage, value); }
        }

        private void OnStatusBarMessageUpdateEvent(string statusBarMessage)
        {
            this.StatusBarMessage = statusBarMessage;
        }

        private void GetSavedSettings()
        {
            var SavedTheme = _globalConfigService.Get(AppSettingsParam.AppTheme);
            var SavedColor = _globalConfigService.Get(AppSettingsParam.AppColor);

            ThemeManager.ChangeAppTheme(Application.Current, SavedTheme.ToString());

            var NewTheme = ThemeManager.DetectAppStyle(Application.Current);
            var NewColor = ThemeManager.GetAccent(SavedColor.ToString());

            ThemeManager.ChangeAppStyle(Application.Current, NewColor, NewTheme.Item1);
        }
    }
}