using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Microsoft.Practices.Unity;

namespace MST.WPFApp.Infrastructure.Base
{
    public class ViewModelBase : BindableBase
    {
        private IUnityContainer unityContainer;
        private IRegionManager regionManager;
        private IEventAggregator eventAggregator;

        public ViewModelBase()
        {
            this.Container = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IUnityContainer>();
            this.RegionManager = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IRegionManager>();
            this.EventAggregator = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IEventAggregator>();
        }

        public IUnityContainer Container
        {
            get { return unityContainer; }
            private set { this.SetProperty<IUnityContainer>(ref this.unityContainer, value); }
        }

        public IRegionManager RegionManager
        {
            get { return regionManager; }
            private set { this.SetProperty<IRegionManager>(ref this.regionManager, value); }
        } 

        public IEventAggregator EventAggregator
        {
            get { return eventAggregator; }
            private set { this.SetProperty<IEventAggregator>(ref this.eventAggregator, value); }
        }
    }
}
