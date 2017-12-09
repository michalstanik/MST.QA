using MST.QA.DataModel;
using MST.QA.DataModel.Projects;
using System.Collections.Generic;
using System.ServiceModel;

namespace MST.QA.Server.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        Project GetProject(int projectId);

        [OperationContract]
        IEnumerable<Project> GetAllProjects();

        [OperationContract]
        IEnumerable<LookupItem> GetProjectLookup();
    }
}
