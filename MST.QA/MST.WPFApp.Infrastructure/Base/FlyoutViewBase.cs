using MahApps.Metro.Controls;
using MST.WPFApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MST.WPFApp.Infrastructure.Base
{
    public class FlyoutViewBase : Flyout 
    {
        public FlyoutViewBase()
        {
            // Programmatically bind the view-model's ViewLoaded property to the view's ViewLoaded property.
            BindingOperations.SetBinding(this, ViewLoadedProperty, new Binding("ViewLoaded"));

            //DataContextChanged += OnDataContextChanged;
        }

        public static readonly DependencyProperty ViewLoadedProperty =
            DependencyProperty.Register("ViewLoaded", typeof(object), typeof(FlyoutViewBase),
            new PropertyMetadata(null));
    }
}
