
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.ModelTestSuits.Views;

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