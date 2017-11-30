using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using System.ComponentModel.DataAnnotations;

namespace MST.QA.DataModel.Projects
{
    public class ProjectType : EntityBase, IIdentifiableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectTypeName { get; set; }

        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}