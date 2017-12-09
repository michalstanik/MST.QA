using MST.QA.Client.WPF.Services;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.Core.UI;
using MST.QA.DataModel.Projects;
using System.Threading.Tasks;

namespace MST.QA.Client.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool isProjectLoadedFlyoutOpen;

        public MainWindowViewModel(IServiceFactory serviceFactory, IMessageDialogService messageDialogService)
        {
            _serviceFactory = serviceFactory;
            _messageDialogService = messageDialogService;
           
            ProjectLoadedFlyoutViewModel = new ProjectLoadedFlyoutViewModel(() => IsProjectLoadedFlyoutOpen = false);

            Settings = new RelayCommand(_ => OnSettingsCommand());
        }

        IServiceFactory _serviceFactory;
        IMessageDialogService _messageDialogService;

        public async Task LoadAsync()
        {
            if (BasedProject == null)
            {
                
                var result = await _messageDialogService.AskQuestionAsync("task", "task");
                IsProjectLoadedFlyoutOpen = true;

            }
        }

        private void OnSettingsCommand()
        {
            IsProjectLoadedFlyoutOpen = true;
        }

        public Project BasedProject { get; set; }
        public ProjectLoadedFlyoutViewModel ProjectLoadedFlyoutViewModel { get; set; }
        public RelayCommand Settings { get; private set; }

        public bool IsProjectLoadedFlyoutOpen
        {
            get { return isProjectLoadedFlyoutOpen; }
            set
            {
                if (value.Equals(isProjectLoadedFlyoutOpen)) return;
                isProjectLoadedFlyoutOpen = value;
                OnPropertyChanged();
            }
        }

    }
}
