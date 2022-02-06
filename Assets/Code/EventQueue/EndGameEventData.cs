namespace Code.EventQueue
{
    public class EndGameEventData : LocalEventData
    {
        public readonly bool Win;
        public EndGameEventData(bool win) : base(EventIds.OnEndGame)
        {
            Win = win;
        }
    }
}