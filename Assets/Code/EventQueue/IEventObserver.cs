namespace Code.EventQueue
{
    public interface IEventObserver
    {
        void Process(LocalEventData eventData);
    }
}