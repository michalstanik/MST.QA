using Prism.Mvvm;
using System.Windows.Media;

namespace MST.WPFApp.Shell.Model
{
    public class AccentColor : BindableBase
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { this.SetProperty<string>(ref this.name, value); }
        }

        private Brush colorBrush;

        public Brush ColorBrush
        {
            get { return colorBrush; }
            set { this.SetProperty<Brush>(ref this.colorBrush, value); }
        }
    }
}
