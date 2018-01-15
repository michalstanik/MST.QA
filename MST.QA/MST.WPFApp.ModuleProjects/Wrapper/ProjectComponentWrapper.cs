using MST.QA.DataModel.Projects;
using MST.WPFApp.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MST.WPFApp.ModuleProjects.Wrapper
{
    public class ProjectComponentWrapper : ModelWrapper<ProjectComponent>
    {
        public ProjectComponentWrapper(ProjectComponent model) : base(model)
        {

        }

        public string ComponentName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
