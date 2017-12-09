using MST.QA.Client.WPF.Services;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.Core.UI;
using MST.QA.DataModel.Projects;
using System.ComponentModel.Composition;
using System;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using MST.QA.Core.Data;

namespace MST.QA.Client.WPF.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewMoodel : ViewModelBase
    {

        [Import]
        public DashboardViewModel DashboardViewModel { get; private set; }

        [Import]
        public TestSuitsViewModel TestSuitsViewModel { get; private set; }
    }
}

