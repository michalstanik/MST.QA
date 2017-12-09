using MST.QA.Core.DataInterfaces;
using MST.QA.DataModel;
using MST.QA.DataModel.Projects;
using System.Collections.Generic;

namespace MST.QA.Data.Contracts.RepositoryInterfaces
{
    public interface IProjectRepository : IDataRepository<Project>
    {
        IEnumerable<LookupItem> GetProjectLookup();
    }
}
