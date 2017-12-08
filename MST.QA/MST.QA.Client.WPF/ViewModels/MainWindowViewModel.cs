using MST.QA.Client.WPF.Services;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.DataModel.Projects;
using System.Threading.Tasks;

namespace MST.QA.Client.WPF.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(IServiceFactory serviceFactory, IMessageDialogService messageDialogService)
        {
            _serviceFactory = serviceFactory;
            _messageDialogService = messageDialogService;
        }

        IServiceFactory _serviceFactory;
        IMessageDialogService _messageDialogService;

        public async Task LoadAsync()
        {
            if (BasedProject == null)
            {
                var result = await _messageDialogService.AskQuestionAsync("task", "task");

            }
        }


        public Project BasedProject { get; set; }
    }
}
