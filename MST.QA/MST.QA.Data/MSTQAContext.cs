using MST.QA.Core.DataInterfaces;
using MST.QA.DataModel.Projects;
using MST.QA.DataModel.Tests;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.Serialization;

namespace MST.QA.Data
{
    public class MSTQAContext : DbContext
    {
        public MSTQAContext() : base("MSTDB")
        {

        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }

        public DbSet<ProjectComponent> ProjectComponents { get; set; }

        public DbSet<TestSuite> TestSuites { get; set; }

        public DbSet<TestCase> TestCases { get; set; }

        public DbSet<TestStep> TestSteps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Ignore<IIdentifiableEntity>();
            modelBuilder.Ignore<ExtensionDataObject>();

            modelBuilder.Entity<Project>().HasKey<int>(e => e.ProjectId).Ignore(e => e.EntityId);
            modelBuilder.Entity<ProjectType>().HasKey<int>(e => e.Id).Ignore(e => e.EntityId);
            modelBuilder.Entity<ProjectComponent>().HasKey<int>(e => e.Id).Ignore(e => e.EntityId);
            modelBuilder.Entity<TestSuite>().HasKey<int>(e => e.Id).Ignore(e => e.EntityId);
            modelBuilder.Entity<TestCase>().HasKey<int>(e => e.Id).Ignore(e => e.EntityId);
            modelBuilder.Entity<TestStep>().HasKey<int>(e => e.Id).Ignore(e => e.EntityId);
        }
    }
}
