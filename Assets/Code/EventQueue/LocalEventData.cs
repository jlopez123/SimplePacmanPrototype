namespace Code.EventQueue
{
    public class LocalEventData
    {
        public readonly EventIds EventId;

        public LocalEventData(EventIds eventId)
        {
            EventId = eventId;
        }
    }
}