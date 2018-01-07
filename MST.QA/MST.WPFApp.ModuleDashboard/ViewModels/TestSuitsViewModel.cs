using MST.WPFApp.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;

namespace MST.WPFApp.ModuleDashboard.ViewModels
{
    public class TestSuitsViewModel : ViewModelBase
    {
        public TestSuitsViewModel()
        {
            Title = "Test Suits";
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
    }
}
