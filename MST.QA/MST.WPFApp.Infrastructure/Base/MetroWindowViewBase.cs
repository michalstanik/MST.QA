using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Data;

namespace MST.WPFApp.Infrastructure.Base
{
    public class MetroWindowViewBase : MetroWindow
    {
        public MetroWindowViewBase()
        {
            // Programmatically bind the view-model's ViewLoaded property to the view's ViewLoaded property.
            BindingOperations.SetBinding(this, ViewLoadedProperty, new Binding("ViewLoaded"));

            //DataContextChanged += OnDataContextChanged;
        }

        public static readonly DependencyProperty ViewLoadedProperty =
                DependencyProperty.Register("ViewLoaded", typeof(object), typeof(MetroWindowViewBase),
                new PropertyMetadata(null));

        //protected virtual void OnUnwireViewModelEvents(ViewModelBase viewModel) { }

        //protected virtual void OnWireViewModelEvents(ViewModelBase viewModel) { }

        //void OnDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        //{
        //    if (e.NewValue == null)
        //    {
        //        if (e.OldValue != null)
        //        {
        //            // view going out of scope and view-model disconnected (but still around in the parent)
        //            // unwire events to allow view to dispose

        //            OnUnwireViewModelEvents(e.OldValue as ViewModelBase);
        //        }
        //    }
        //    else
        //    {
        //        OnWireViewModelEvents(e.NewValue as ViewModelBase);
        //    }
        //}
    }
}
