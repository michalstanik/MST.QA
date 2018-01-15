using MST.QA.Client.Contracts.ServiceContracts;
using System.ServiceModel;
using MST.QA.DataModel.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using MST.QA.DataModel;

namespace MST.QA.Client.Proxies.ServiceProxies
{
    [Export(typeof(IProjectService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProjectClient : ClientBase<IProjectService>, IProjectService
    {
        public  IEnumerable<Project> GetAllProjects()
        {
            return  Channel.GetAllProjects();
        }

        public Project GetProject(int projectId)
        {
            return  Channel.GetProject(projectId);
        }

        public IEnumerable<LookupItem> GetProjectLookup()
        {
            return Channel.GetProjectLookup();
        }

        public IEnumerable<LookupItem> GetProjectTypeLookup()
        {
            return Channel.GetProjectTypeLookup();
        }
    }
}
