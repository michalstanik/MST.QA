using System.Collections.Generic;
using System.Threading.Tasks;
using MST.QA.DataModel;
using MST.QA.Core.ServiceInterfaces;
using MST.WPFApp.Infrastructure.Base;
using MST.QA.Client.Contracts.ServiceContracts;
using System.Linq;
using System.Data.Entity;

namespace MST.WPFApp.ModuleProjects.Lookups
{
    public class ProjectLookupDataService : ViewModelBase, IProjectLookupDataService
    {
        private IServiceFactory _serviceFactory;
        private IEnumerable<LookupItem> _projects;
        private IEnumerable<LookupItem> _projectTypes;

        public ProjectLookupDataService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public IEnumerable<LookupItem> GetProjectLookupAsync()
        {
            WithClient<IProjectService>(_serviceFactory.CreateClient<IProjectService>(), projectClient =>
            {
                _projects = projectClient.GetProjectLookup();
            });

            return _projects;
        }

        public IEnumerable<LookupItem> GetProjectTypeLookupAsync()
        {
            WithClient<IProjectService>(_serviceFactory.CreateClient<IProjectService>(), projectClient =>
            {
                _projectTypes = projectClient.GetProjectTypeLookup();
            });

            return _projectTypes;
        }
    }
}