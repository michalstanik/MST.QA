using MahApps.Metro;
using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.Infrastructure.Interfaces;
using System.Windows;

namespace MST.WPFApp.Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IGlobalConfigService _globalConfigService;

        public MainWindowViewModel(IGlobalConfigService globalConfigService)
        {
            _globalConfigService = globalConfigService;
            GetSavedTheme();
        }

        private void GetSavedTheme()
        {
            var SavedTheme = _globalConfigService.Get(AppSettingsParam.AppTheme);
            ThemeManager.ChangeAppTheme(Application.Current, SavedTheme.ToString());
        }
    }
}
