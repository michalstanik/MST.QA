using MST.WPFApp.ModelTestSuits.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using MST.WPFApp.Infrastructure.Constants;

namespace MST.WPFApp.ModelTestSuits
{
    public class ModelTestSuitsModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModelTestSuitsModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(TestSuitsView));
        }
    }
}