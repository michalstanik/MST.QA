using MST.QA.Data.DataRepositories;
using System.ComponentModel.Composition.Hosting;

namespace MST.QA.Server.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProjectRepository).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
