using System.Collections.Generic;
using MST.QA.DataModel.Projects;
using System.Linq;
using MST.QA.Data.Contracts.RepositoryInterfaces;
using System.ComponentModel.Composition;
using MST.QA.DataModel;

namespace MST.QA.Data.DataRepositories
{
    [Export(typeof(IProjectRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProjectRepository : DataRepositoryBase<Project>, IProjectRepository
    {
        public IEnumerable<LookupItem> GetProjectLookup()
        {
            using (MSTQAContext entityContext = new MSTQAContext())
            {
                return entityContext.Projects.AsNoTracking()
                    .Select(f =>
                    new LookupItem
                    {
                        Id = f.ProjectId,
                        DisplayMember = f.ProjectName
                    })
                    .ToList();
            }
        }

        public IEnumerable<LookupItem> GetProjectTypeLookup()
        {
            using (MSTQAContext entityContext = new MSTQAContext())
            {
                return entityContext.ProjectTypes.AsNoTracking()
                    .Select(f =>
                    new LookupItem
                    {
                        Id = f.Id,
                        DisplayMember = f.ProjectTypeName
                    })
                    .ToList();
            }

        }

        protected override Project AddEntity(MSTQAContext entityContext, Project entity)
        {
            return entityContext.Projects.Add(entity);
        }

        protected override IEnumerable<Project> GetEntities(MSTQAContext entityContext)
        {
            return from e in entityContext.Projects
                   select e;
        }

        protected override Project GetEntity(MSTQAContext entityContext, int id)
        {
            var query = (from e in entityContext.Projects
                         where e.ProjectId == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Project UpdateEntity(MSTQAContext entityContext, Project entity)
        {
            return (from e in entityContext.Projects
                    where e.ProjectId == entity.ProjectId
                    select e).FirstOrDefault();
        }
    }
}
