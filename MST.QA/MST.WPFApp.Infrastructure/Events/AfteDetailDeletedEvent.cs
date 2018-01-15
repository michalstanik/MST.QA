using Prism.Events;

namespace MST.WPFApp.Infrastructure.Events
{
    public class AfteDetailDeletedEvent : PubSubEvent<AfteDetailDeletedEventArgs>
    {

    }

    public class AfteDetailDeletedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
        public string ViewModelName { get; set; }
    }
}
