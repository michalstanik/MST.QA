using MST.QA.Core.Data;
using MST.QA.Core.ServiceInterfaces;
using System.ComponentModel.Composition;

namespace MST.QA.Client.Proxies
{
    [Export(typeof(IServiceFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServiceFactory : IServiceFactory
    {
        public T CreateClient<T>() where T : IServiceContract
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
