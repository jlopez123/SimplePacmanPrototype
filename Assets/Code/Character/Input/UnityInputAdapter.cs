using UnityEngine;

namespace Code.Character.Input
{
    public class UnityInputAdapter : ICharacterInput
    {
        public Vector2 GetDirection()
        {
            var horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            var vertical = UnityEngine.Input.GetAxisRaw("Vertical");

            if (horizontal != 0)
                return horizontal > 0 ? Vector2.right : Vector2.left;
            if (vertical != 0)
                return vertical > 0 ? Vector2.up : Vector2.down;
        
            return Vector2.zero;
        }
    }
}