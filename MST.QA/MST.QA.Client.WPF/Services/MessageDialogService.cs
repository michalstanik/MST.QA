using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MST.QA.Client.WPF.Views;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;

namespace MST.QA.Client.WPF.Services
{
    [Export(typeof (IMessageDialogService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MessageDialogService : IMessageDialogService
    {   

        MainWindow _metroWindow;

        public MessageDialogService()
        {

        }

        public MessageDialogService(MainWindow metroWindow)
        {
            _metroWindow = metroWindow;
        }

        public Task<MessageDialogResult> AskQuestionAsync(string title, string message)
        {
            var settings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
            };
            return _metroWindow.ShowMessageAsync(title, message,
                MessageDialogStyle.AffirmativeAndNegative, settings);
        }

        public MessageDialogResult ShowOkCancelDialog(string text, string title)
        {
            var result = MessageBox.Show(text, title, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK
                ? MessageDialogResult.Affirmative
                : MessageDialogResult.Negative;
        }
    }
}
