using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MST.QA.Core.UI
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public virtual string ViewTitle
        {
            get { return String.Empty; }
        }

        public object ViewLoaded
        {
            get
            {
                OnViewLoaded();
                return null;
            }
        }

        protected virtual void OnViewLoaded() { }

        protected void WithClient<T>(T proxy, Action<T> codeToExecute)
        {
            codeToExecute.Invoke(proxy);

            IDisposable disposableClient = proxy as IDisposable;
            if (disposableClient != null)
                disposableClient.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
