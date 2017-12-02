using MST.QA.Core.ServiceInterfaces;
using MST.QA.DataModel.Projects;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MST.QA.Client.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface IProjectService :IServiceContract
    {
        [OperationContract]
        Project GetProject(int projectId);

        [OperationContract]
        IEnumerable<Project> GetAllProjects();
    }
}
