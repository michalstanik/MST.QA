using MST.QA.Client.Contracts.ServiceContracts;
using MST.QA.Core.ServiceInterfaces;
using MST.QA.Core.UI;
using MST.QA.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MST.QA.Client.WPF.ViewModels
{
    public class ProjectLoadedFlyoutViewModel : ViewModelBase
    {
        public ProjectLoadedFlyoutViewModel(IServiceFactory serviceFactory, Action closeAction)
        {
            _serviceFactory = serviceFactory;
            OkCommand = new RelayCommand(_ => closeAction());
        }
        public RelayCommand OkCommand { get; private set; }
        private ObservableCollection<LookupItem> _projects;
        IServiceFactory _serviceFactory;

        protected override void OnViewLoaded()
        {
            _projects = new ObservableCollection<LookupItem>();

            WithClient<IProjectService>(_serviceFactory.CreateClient<IProjectService>(), projectClient =>
            {
                IEnumerable<LookupItem> projects = projectClient.GetProjectLookup();

                if (projects != null)
                {
                    foreach (LookupItem project in projects)
                    {
                        _projects.Add(project);
                    }
                }
            });
        }

        public ObservableCollection<LookupItem> Projects
        {
            get { return _projects; }
            private set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }
    }
}
