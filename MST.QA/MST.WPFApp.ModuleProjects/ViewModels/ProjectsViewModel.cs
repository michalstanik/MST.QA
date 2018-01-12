using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Events;
using MST.WPFApp.Infrastructure.Interfaces;
using Prism.Events;
using System.Threading.Tasks;
using System;
using MST.WPFApp.ModuleProjects.Interfaces;

namespace MST.WPFApp.ModuleProjects.ViewModels
{
    public class ProjectsViewModel : ViewModelBase
    {

        private IDetailViewModel _detailViewModel;
        private Func<IProjectDetailViewModel> _projectDetailViewModelCreator;

        public ProjectsViewModel(INavigationViewModel navigationModel, Func<IProjectDetailViewModel> projectDetailViewModelCreator)
        {

            _projectDetailViewModelCreator = projectDetailViewModelCreator;

            Title = "Projects";

            ProjectNavigationViewModel = navigationModel;

            EventAggregator.GetEvent<OpenDetailViewEvent>().Subscribe(OnOpenDetailView);
        }

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            if (DetailViewModel != null && DetailViewModel.HasChanges)
            {

            }
            switch (args.ViewModelName)
            {
                case nameof(ProjectDetailViewModel):
                    DetailViewModel = _projectDetailViewModelCreator();
                    break;
            }
            await DetailViewModel.LoadAsync(args.Id);
        }

        public INavigationViewModel ProjectNavigationViewModel { get; }

        public IDetailViewModel DetailViewModel
        {
            get { return _detailViewModel; }
            private set
            {
                _detailViewModel = value;
                OnPropertyChanged();
            }
        }

        protected override void OnViewLoaded()
        {
            ProjectNavigationViewModel.LoadAsync();
        }
    }
}
