using MST.QA.Client.Bootstrapper;
using MST.QA.Core.Data;
using Prism.Events;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Windows;

namespace MST.QA.Client.WPF
{
    public partial class App : Application
    {
        public IEventAggregator eventAggregator;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ObjectBase.Container = MEFLoader.Init(new List<ComposablePartCatalog>()
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            });
            eventAggregator = new EventAggregator();

            var compositionBatch = new CompositionBatch();
            compositionBatch.AddExportedValue(this.eventAggregator);

            ObjectBase.Container.Compose(compositionBatch);

        }
    }
}
