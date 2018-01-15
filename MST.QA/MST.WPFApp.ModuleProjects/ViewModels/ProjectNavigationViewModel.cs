using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Events;
using MST.WPFApp.Infrastructure.Interfaces;
using MST.WPFApp.Infrastructure.ViewModels;
using MST.WPFApp.ModuleProjects.Lookups;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            EventAggregator.GetEvent<AfterDetailSavedEvent>().Subscribe(AfterDetailSaved);
            EventAggregator.GetEvent<AfteDetailDeletedEvent>().Subscribe(AfterDetailDeleted);
        }

        public ObservableCollection<NavigationItemViewModel> Projects { get; }

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            switch (args.ViewModelName)
            {
                case nameof(ProjectDetailViewModel):
                    var project = Projects.SingleOrDefault(p => p.Id == args.Id);
                    if (project != null)
                    {
                        Projects.Remove(project);
                    }
                    break;
            }
        }

        private void AfterDetailDeleted(AfteDetailDeletedEventArgs obj)
        {
            switch (obj.ViewModelName)
            {
                case nameof(ProjectDetailViewModel):
                    var lookupItem = Projects.SingleOrDefault(l => l.Id == obj.Id);
                    if (lookupItem == null)
                    {
                        Projects.Add(new NavigationItemViewModel(obj.Id, obj.DisplayMember,
                            nameof(ProjectDetailViewModel)));
                    }
                    else
                    {
                        lookupItem.DisplayMember = obj.DisplayMember;
                    }
                    break;
            }
        }
    
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
