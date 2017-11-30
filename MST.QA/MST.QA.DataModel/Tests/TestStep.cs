using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MST.QA.DataModel.Tests
{
    public class TestStep : EntityBase, IIdentifiableEntity
    {
        public TestStep()
        {
            TestCases = new Collection<TestCase>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TestStepName { get; set; }

        public string TestStepDescription { get; set; }

        public ICollection<TestCase> TestCases { get; set; }

        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}