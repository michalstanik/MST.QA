using MahApps.Metro.Controls;
using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Constants;
using MST.WPFApp.Infrastructure.Interfaces;

namespace MST.WPFApp.Shell.Views
{
    /// <summary>
    /// Interaction logic for ShellSettingsFlyout.xaml
    /// </summary>
    public partial class ShellSettingsFlyout : FlyoutViewBase, IFlyoutView
    {
        public ShellSettingsFlyout()
        {
            InitializeComponent();
        }

        public string FlyoutName
        {
            get { return FlyoutNames.ShellSettingsFlyout; }
        }
    }
}
