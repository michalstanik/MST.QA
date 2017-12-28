using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Windows;
using MST.WPFApp.Infrastructure.Constants;
using Prism.Regions;
using MST.WPFApp.Shell.Views;
using MST.WPFApp.Infrastructure;
using MST.WPFApp.Infrastructure.Interfaces;
using MST.WPFApp.Infrastructure.Services;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.Client.Proxies;
using Prism.Logging;
using Prism.Modularity;

namespace MST.WPFApp.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Container.RegisterInstance(typeof(Window), WindowNames.MainWindowName, Container.Resolve<MainWindow>(), new ContainerControlledLifetimeManager());
            return Container.Resolve<Window>(WindowNames.MainWindowName);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            var regionManager = this.Container.Resolve<IRegionManager>();
            if (regionManager != null)
            {
                // Add right windows commands
                regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));
                // Add flyouts
                regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(ShellSettingsFlyout));
                // Add tiles to MainRegion
                regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(TabControlView));
            }

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;

           moduleCatalog.AddModule(typeof(ModuleDashboard.ModuleDashboardModule));
           moduleCatalog.AddModule(typeof(ModelTestSuits.ModelTestSuitsModule));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IApplicationCommands, ApplicationCommandsProxy>();
            Container.RegisterType<ISettings, AppSettings>();

            Container.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());

            Container.RegisterInstance<IGlobalConfigService>(Container.Resolve<GlobalConfigService>());

            Container.RegisterInstance<IServiceFactory>(Container.Resolve<ServiceFactory>());
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new Logging.NLogLogger();
        }
    }
}
