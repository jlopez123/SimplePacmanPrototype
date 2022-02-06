using Code.Character;

namespace Code.EventQueue
{
    public class GameUnitEventData : LocalEventData
    {
        public readonly GameUnitController GameUnitController;

        public GameUnitEventData(EventIds eventId, GameUnitController gameUnitController) : base(eventId)
        {
            GameUnitController = gameUnitController;
        }
    }
}