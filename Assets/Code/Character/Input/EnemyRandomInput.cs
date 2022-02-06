using UnityEngine;

namespace Code.Character.Input
{
    public class EnemyRandomInput : MonoBehaviour, ICharacterInput
    {

        private Vector2 _currentDirection;

        public void Configure(Vector2 initialDirection)
        {
            _currentDirection = initialDirection;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var nodeMarker = other.GetComponent<NodeMarker>();
            if( nodeMarker == null)
                return;
        
            var rnd = new System.Random();
            _currentDirection = nodeMarker.AvailableDirections[rnd.Next(0,nodeMarker.AvailableDirections.Count)];
            //GetComponent<CharacterMovement>().TrySetNewDirection(newDirection);
        }

        public Vector2 GetDirection() => _currentDirection;
    }
}
