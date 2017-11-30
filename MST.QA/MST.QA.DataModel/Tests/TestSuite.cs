using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using MST.QA.DataModel.Projects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MST.QA.DataModel.Tests
{
    public class TestSuite : EntityBase, IIdentifiableEntity
    {
        public TestSuite()
        {
            TestCases = new Collection<TestCase>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TestSuiteName { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public ICollection<TestCase> TestCases { get; set; }

        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}