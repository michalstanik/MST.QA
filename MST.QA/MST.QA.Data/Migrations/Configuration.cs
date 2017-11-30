namespace MST.QA.Data.Migrations
{
    using MST.QA.DataModel.Projects;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MST.QA.Data.MSTQAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MST.QA.Data.MSTQAContext context)
        {
            context.Projects.AddOrUpdate(
                            f => f.ProjectName,
                            new Project { ProjectName = "Project1", ProjectDescription = "ProjectDescription 1" },
                            new Project { ProjectName = "Project2", ProjectDescription = "ProjectDescription 2" },
                            new Project { ProjectName = "Project3", ProjectDescription = "ProjectDescription 3" }
                            );
            context.ProjectTypes.AddOrUpdate(
                pt => pt.ProjectTypeName,
                new ProjectType { ProjectTypeName = "Type 1" },
                new ProjectType { ProjectTypeName = "Type 2" },
                new ProjectType { ProjectTypeName = "Type 3" },
                new ProjectType { ProjectTypeName = "Type 4" },
                new ProjectType { ProjectTypeName = "Type 5" }
                );

            context.SaveChanges();

            context.ProjectComponents.AddOrUpdate(pc => pc.ComponentName,
                new ProjectComponent { ComponentName = "Component 1", ProjectId = context.Projects.First().ProjectId }
                );
        }
    }
}
