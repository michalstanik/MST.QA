using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Interfaces;
using MST.WPFApp.Infrastructure.ViewModels;
using MST.WPFApp.ModuleProjects.Lookups;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MST.WPFApp.ModuleProjects.ViewModels
{
    public class ProjectNavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IProjectLookupDataService _projectLookupService;

        public ProjectNavigationViewModel(IProjectLookupDataService projectLookupService)
        {
            _projectLookupService = projectLookupService;

            Projects = new ObservableCollection<NavigationItemViewModel>();
        }

        public ObservableCollection<NavigationItemViewModel> Projects { get; }

        public async Task LoadAsync()
        {
            var lookup =  _projectLookupService.GetProjectLookupAsync();
            Projects.Clear();
            foreach (var item in lookup)
            {
                Projects.Add(new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof(ProjectDetailViewModel)));
            }
        }
    }
}
