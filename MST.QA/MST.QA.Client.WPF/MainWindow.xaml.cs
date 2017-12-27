using System;
using System.Windows;
using MahApps.Metro.Controls;
using MST.QA.Client.WPF.ViewModels;
using MST.QA.Core.Data;
using System.ComponentModel.Composition;
using MST.QA.Client.WPF.Services;
using MST.QA.Core.ServiceInterfaces;
using Prism.Events;

namespace MST.QA.Client.WPF
{
    
    public partial class MainWindow : MetroWindow
    {
        private MainWindowViewModel _viewModel;

        //[ImportingConstructor]
        public MainWindow()
        {
            InitializeComponent();
            var factory = ObjectBase.Container.GetExportedValue<IServiceFactory>();
            _viewModel = new MainWindowViewModel(factory, new MessageDialogService(this));
            this.DataContext = _viewModel;
            Loaded += MainWindow_Loaded;

            main.DataContext = ObjectBase.Container.GetExportedValue<MainViewMoodel>();

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
            
        }
    }
}
