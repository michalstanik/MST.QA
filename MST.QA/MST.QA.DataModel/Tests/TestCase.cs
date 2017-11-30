using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MST.QA.DataModel.Tests
{
    public class TestCase : EntityBase, IIdentifiableEntity
    {
        public TestCase()
        {
            TestSteps = new Collection<TestStep>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TestCaseName { get; set; }

        public string TestCaseDescription { get; set; }

        public TestSuite TestSuite { get; set; }

        public ICollection<TestStep> TestSteps { get; set; }

        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
