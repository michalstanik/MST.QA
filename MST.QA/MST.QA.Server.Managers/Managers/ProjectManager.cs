using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using MST.QA.Core.Exceptions;
using MST.QA.Data.Contracts.RepositoryInterfaces;
using MST.QA.DataModel.Projects;
using MST.QA.Server.Contracts.ServiceContracts;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel;

namespace MST.QA.Server.Managers.Managers
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class ProjectManager : ManagerBase, IProjectService
    {
        public ProjectManager()
        {

        }

        public ProjectManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _dataRepositoryFactory;

        [OperationBehavior(TransactionScopeRequired = true)]
        public Project GetProject(int projectId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IProjectRepository projectRepository = _dataRepositoryFactory.GetDataRepository<IProjectRepository>();

                Project projectEntity = projectRepository.Get(projectId);
                if (projectEntity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("Project with ID of {0} is not in database", projectId));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return projectEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public IEnumerable<Project> GetAllProjects()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IProjectRepository projectRepository = _dataRepositoryFactory.GetDataRepository<IProjectRepository>();

                IEnumerable<Project> Projects = projectRepository.Get();

                return Projects;
            });
        }
    }
}
