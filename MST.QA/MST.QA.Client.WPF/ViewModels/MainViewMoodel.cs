using System.ComponentModel.Composition;

namespace MST.QA.Client.WPF.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewMoodel
    {
        [Import]
        public DashboardViewModel DashboardViewModel { get; private set; }

        [Import]
        public TestSuitsViewModel TestSuitsViewModel { get; private set; }
    }
}
