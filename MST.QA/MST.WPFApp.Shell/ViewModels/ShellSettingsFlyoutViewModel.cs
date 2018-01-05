using MahApps.Metro;
using MST.QA.Client.Contracts.ServiceContracts;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.DataModel;
using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.Infrastructure.Events;
using MST.WPFApp.Infrastructure.Interfaces;
using MST.WPFApp.Shell.Model;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Microsoft.Practices.Unity;

namespace MST.WPFApp.Shell.ViewModels
{
    public class ShellSettingsFlyoutViewModel : ViewModelBase
    {
        private IGlobalConfigService _globalConfigService;
        private IServiceFactory _serviceFactory;

        private AccentColor selectedAccentColor;
        private ApplicationTheme selectedTheme;
        private IList<ApplicationTheme> applicationsThemes;
        private IList<AccentColor> accentColors;
        private ObservableCollection<LookupItem> _projects;

        public ShellSettingsFlyoutViewModel(IGlobalConfigService globalConfigService, IServiceFactory serviceFactory)
        {
            _globalConfigService = globalConfigService;
            _serviceFactory = serviceFactory;

            this.ApplicationThemes = ThemeManager.AppThemes
                .Select(a => new ApplicationTheme() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                .ToList();

            this.AccentColors = ThemeManager.Accents
                                .Select(a => new AccentColor() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                .ToList();

            Container.Resolve<ILoggerFacade>().Log("ShellSettingsFlyoutViewModel created", Category.Info, Priority.None);
        }

        public IList<ApplicationTheme> ApplicationThemes
        {
            get { return applicationsThemes; }
            set { this.SetProperty<IList<ApplicationTheme>>(ref this.applicationsThemes, value); }
        }

        

        public IList<AccentColor> AccentColors
        {
            get { return accentColors; }
            set { this.SetProperty<IList<AccentColor>>(ref this.accentColors, value); }
        }

        public ObservableCollection<LookupItem> Projects
        {
            get { return _projects; }
            set { this.SetProperty<ObservableCollection<LookupItem>>(ref this._projects, value); }
        }

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

                    _globalConfigService.Update(AppSettingsParam.AppColor, accent.Name);

                    EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(String.Format("Accent color changed to {0}", value.Name));
                }
            }
        }

        protected override void OnViewLoaded()
        {
            _projects = new ObservableCollection<LookupItem>();

            WithClient<IProjectService>(_serviceFactory.CreateClient<IProjectService>(), projectClient =>
            {
                IEnumerable<LookupItem> projects = projectClient.GetProjectLookup();

                if (projects != null)
                {
                    foreach (LookupItem project in projects)
                    {
                        _projects.Add(project);
                    }
                }
            });
        }

    }
}
