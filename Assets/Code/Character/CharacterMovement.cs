using UnityEngine;

namespace Code.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private bool _saveNextDirection = false;
    
        private Vector2 _currentDirection;

        public Vector2 CurrentDirection => _currentDirection;

        private CharacterSensors _characterSensors;
    
        private Vector2 _nextDirection = Vector2.zero;

        public void Configure(Vector2 initialDirection, CharacterSensors characterSensors)
        {
            _currentDirection = initialDirection;
            _characterSensors = characterSensors;
        }
        public void DoMove()
        {
            if(_saveNextDirection && _nextDirection != Vector2.zero)
                TrySetNewDirection(_nextDirection);
        
            var step = _currentDirection * _speed * Time.deltaTime;
            _rigidbody2D.MovePosition(_rigidbody2D.position + step);
            //    _rigidbody2D.velocity = _currentDirection * _speed;
        }
        public void TrySetNewDirection(Vector2 direction)
        {
            if (_characterSensors.CheckForWallInDirection(direction))
            {
                _nextDirection = direction;
                return;
            }


            if (direction == Vector2.zero)
                return;

            _currentDirection = direction;
            _nextDirection = Vector2.zero;
        }
    }
}