using Prism.Mvvm;
using System.Windows.Media;

namespace MST.WPFApp.Shell.Model
{
    public class ApplicationTheme : BindableBase
    {
        private string name;
        private Brush colorBrush;
        private Brush borderColorBrush;

        public string Name
        {
            get { return name; }
            set { this.SetProperty<string>(ref this.name, value); }
        }

        public Brush ColorBrush
        {
            get { return colorBrush; }
            set { this.SetProperty<Brush>(ref this.colorBrush, value); }
        }

        public Brush BorderColorBrush
        {
            get { return borderColorBrush; }
            set { this.SetProperty<Brush>(ref this.borderColorBrush, value); }
        }
    }
}
