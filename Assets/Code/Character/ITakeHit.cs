namespace Code.Character
{
    public interface ITakeHit
    {
        bool IsAlive { get; }
        bool CanTakeHit { get; }

        void TakeHit(int damage);

    }
}