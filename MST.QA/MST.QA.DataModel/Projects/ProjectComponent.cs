using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using System.ComponentModel.DataAnnotations;

namespace MST.QA.DataModel.Projects
{
    public class ProjectComponent : EntityBase, IIdentifiableEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ComponentName { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}