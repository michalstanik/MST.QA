using MST.WPFApp.ModuleDashboard.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using MST.WPFApp.Infrastructure.Constants;

namespace MST.WPFApp.ModuleDashboard
{
    public class ModuleDashboardModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleDashboardModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(DasboardView));
            //_regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(TestSuitsView));

            _container.RegisterType<object, DasboardView>("ViewA");
            _container.RegisterType<object, TestSuitsView>("ViewB");
        }
    }
}