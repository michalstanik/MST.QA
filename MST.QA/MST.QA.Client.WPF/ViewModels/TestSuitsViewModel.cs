using MST.QA.Client.Contracts.ServiceContracts;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.Core.UI;
using MST.QA.DataModel.Projects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace MST.QA.Client.WPF.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestSuitsViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public TestSuitsViewModel(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        IServiceFactory _serviceFactory;
        private ObservableCollection<Project> _projects;

        public override string ViewTitle
        {
            get { return "Test Suits"; }
        }

        protected override void OnViewLoaded()
        {
            _projects = new ObservableCollection<Project>();

            WithClient<IProjectService>(_serviceFactory.CreateClient<IProjectService>(), projectClient =>
            {
                IEnumerable<Project> projects = projectClient.GetAllProjects();

                if (projects != null)
                {
                    foreach (Project project in projects)
                    {
                        _projects.Add(project);
                    }
                }
            });
        }

        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
            private set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }
    }
}
