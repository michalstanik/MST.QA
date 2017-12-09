using MST.QA.Core.UI;
using System;

namespace MST.QA.Client.WPF.ViewModels
{
    public class ProjectLoadedFlyoutViewModel : ViewModelBase
    {
        public ProjectLoadedFlyoutViewModel(Action closeAction)
        {
            OkCommand = new RelayCommand(_ => closeAction());
        }
        public RelayCommand OkCommand { get; private set; }
    }
}
