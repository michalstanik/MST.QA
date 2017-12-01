using MST.QA.Client.Contracts.ServiceContracts;
using System.ServiceModel;
using MST.QA.DataModel.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace MST.QA.Client.Proxies.ServiceProxies
{
    [Export(typeof(IProjectService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProjectClient : ClientBase<IProjectService>, IProjectService
    {
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await Channel.GetAllProjects();
        }

        public async Task<Project> GetProject(int projectId)
        {
            return await Channel.GetProject(projectId);
        }
    }
}
