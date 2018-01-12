using System.Threading.Tasks;

namespace MST.WPFApp.Infrastructure.Interfaces
{
    public interface IDetailViewModel
    {
        Task LoadAsync(int? id);
        bool HasChanges { get; }
    }
}
