using UnityEngine;

namespace Code.Character.Input
{
    public interface ICharacterInput
    {
        Vector2 GetDirection();
    }

    public class EmptyInput : ICharacterInput
    {
        public Vector2 GetDirection()
        {
            return Vector2.zero;
        }
    }
}