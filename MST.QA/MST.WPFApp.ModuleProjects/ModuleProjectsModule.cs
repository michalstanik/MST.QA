using MST.WPFApp.ModuleProjects.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using MST.WPFApp.ModuleProjects.Lookups;
using MST.WPFApp.Infrastructure.Interfaces;
using MST.WPFApp.ModuleProjects.ViewModels;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.ModuleProjects.Interfaces;

namespace MST.WPFApp.ModuleProjects
{
    public class ModuleProjectsModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ModuleProjectsModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
           

           _container.RegisterInstance<IProjectLookupDataService>(_container.Resolve<ProjectLookupDataService>());

            _container.RegisterInstance<INavigationViewModel>(_container.Resolve<ProjectNavigationViewModel>());

            _container.RegisterType<IProjectDetailViewModel, ProjectDetailViewModel>();

            _container.RegisterType<object, ProjectsView>("ProjectsView");

        }
    }
}