using MahApps.Metro;
using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.Infrastructure.Events;
using MST.WPFApp.Infrastructure.Interfaces;
using System.Windows;
using System;

namespace MST.WPFApp.Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IGlobalConfigService _globalConfigService;

        public MainWindowViewModel(IGlobalConfigService globalConfigService)
        {
            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);

            _globalConfigService = globalConfigService;
            GetSavedTheme();
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

        private void GetSavedTheme()
        {
            var SavedTheme = _globalConfigService.Get(AppSettingsParam.AppTheme);
            ThemeManager.ChangeAppTheme(Application.Current, SavedTheme.ToString());
        }
    }
}
