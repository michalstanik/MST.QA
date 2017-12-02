using MahApps.Metro.Controls;
using MST.QA.Client.WPF.ViewModels;
using MST.QA.Core.Data;

namespace MST.QA.Client.WPF
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            main.DataContext = ObjectBase.Container.GetExportedValue<MainViewMoodel>();
        }
    }
}
