using MST.WPFApp.Infrastructure.Base;
using MST.WPFApp.Infrastructure.Events;
using Prism.Commands;
using Prism.Events;
using System.Windows.Input;

namespace MST.WPFApp.Infrastructure.ViewModels
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private string _detailViewModelName;

        public NavigationItemViewModel(int id, string displayMember, string detailViewModelName)
        {
            Id = id;
            DisplayMember = displayMember;
            _detailViewModelName = detailViewModelName;
            OpenDetailViewCommand = new DelegateCommand(OnOpeDetailViewExecute);
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set { this.SetProperty<string>(ref this._displayMember, value); }
        }

        public ICommand OpenDetailViewCommand { get; }

        private void OnOpeDetailViewExecute()
        {
            EventAggregator.GetEvent<OpenDetailViewEvent>()
                        .Publish(
                new OpenDetailViewEventArgs
                {
                    Id = Id,
                    ViewModelName = _detailViewModelName
                });
        }
    }
}
