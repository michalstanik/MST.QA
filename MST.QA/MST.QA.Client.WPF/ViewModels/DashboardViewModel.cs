using MST.QA.Core.ServiceInterfaces;
using MST.QA.Core.UI;
using System.ComponentModel.Composition;

namespace MST.QA.Client.WPF.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DashboardViewModel :ViewModelBase
    {
        [ImportingConstructor]
        public DashboardViewModel(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        IServiceFactory _serviceFactory;

        public override string ViewTitle
        {
            get { return "Dashboard"; }
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
        }
    }
}
