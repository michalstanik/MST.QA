using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using MST.QA.DataModel.Tests;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MST.QA.DataModel.Projects
{
    public class Project : EntityBase, IIdentifiableEntity
    {
        public Project()
        {
            ProjectComponents = new Collection<ProjectComponent>();
            TestSuites = new Collection<TestSuite>();
        }

        public int ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public int? ProjectTypeId { get; set; }

        public ProjectType ProjectType { get; set; }

        public ICollection<ProjectComponent> ProjectComponents { get; set; }

        public ICollection<TestSuite> TestSuites { get; set; }

        public int EntityId
        {
            get { return ProjectId; }
            set { ProjectId = value; }
        }
    }
}
