using MST.QA.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MST.WPFApp.ModuleProjects.Lookups
{
    public interface IProjectLookupDataService
    {
        IEnumerable<LookupItem> GetProjectLookupAsync();
    }
}