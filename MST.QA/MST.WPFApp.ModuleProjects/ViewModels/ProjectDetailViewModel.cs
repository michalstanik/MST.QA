using System.Threading.Tasks;
using MST.WPFApp.ModuleProjects.Interfaces;
using MST.WPFApp.Infrastructure.ViewModels;
using System;
using MST.QA.DataModel;
using System.Collections.ObjectModel;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.Client.Contracts.ServiceContracts;
using MST.QA.DataModel.Projects;
using MST.WPFApp.ModuleProjects.Wrapper;

namespace MST.WPFApp.ModuleProjects.ViewModels
{
    public class ProjectDetailViewModel : DetailViewModelBase, IProjectDetailViewModel
    {
        private IServiceFactory _serviceFactory;
        private ProjectWrapper _project;

        public ProjectDetailViewModel(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            ProjectTypes = new ObservableCollection<LookupItem>();
        }


        public ObservableCollection<LookupItem> ProjectTypes { get; }


        public ProjectWrapper Project
        {
            get { return _project; }
            private set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        public override async Task LoadAsync(int? projectId)
        {
            var project = new Project();

            WithClient<IProjectService>(_serviceFactory.CreateClient<IProjectService>(), projectClient =>
            {
                project = projectId.HasValue
                ? projectClient.GetProject(projectId.Value)
                : CreateNewProject();
            });

            InitializeProject(project);

            await LoadProjectTypesLookupAsync();
        }

        private void InitializeProject(Project project)
        {
            Project = new ProjectWrapper(project);
        }

        private Project CreateNewProject()
        {
            throw new NotImplementedException();
        }

        private async Task LoadProjectTypesLookupAsync()
        {
           
        }

        protected override void OnDeleteExecute()
        {
            throw new System.NotImplementedException();
        }

        protected override bool OnSaveCanExecute()
        {
            return Project != null
                && !Project.HasErrors
                && HasChanges;
        }

        protected override void OnSaveExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}
