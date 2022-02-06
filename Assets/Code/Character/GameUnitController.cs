using Code.Character.Input;
using UnityEngine;

namespace Code.Character
{
    public class GameUnitController : MonoBehaviour
    {
        [SerializeField] private Transform _rotationRoot;
        [SerializeField] private Animator _animator;
    
        private CharacterMovement _characterMovement;
        private CharacterSensors _characterSensors;
        private CharacterHealth _health;
        private ICharacterInput _characterInput;
        private ILookAtBehaviour _lookAtBehaviour;

        private bool _canDoAction = true;
        private bool _isInitialized = false;
        private void Awake()
        {
            _lookAtBehaviour = new DirectRotation(_rotationRoot);
            _characterSensors = GetComponent<CharacterSensors>();
        }
        public void Configure(ICharacterInput characterInput, Vector2 initialDirection)
        {
            _characterInput = characterInput;
            
            _characterMovement = GetComponent<CharacterMovement>();
            _characterMovement.Configure(initialDirection, _characterSensors);
            

            
            //
            _health = GetComponent<CharacterHealth>();
            _health.Configure(1, true);
            _health.OnDied += OnCharacterDie;

            _isInitialized = true;
        }

        private void Update()
        {
            if(_isInitialized == false)
                return;
            
            if(_health.IsAlive == false || _canDoAction == false)
                return;
            
            var inputDirection = _characterInput.GetDirection();

            _characterMovement.TrySetNewDirection(inputDirection);
        
            _lookAtBehaviour.DoRotation(_characterMovement.CurrentDirection);
        }

        private void FixedUpdate()
        {
            if(_isInitialized == false)
                return;
            
            if(_health.IsAlive == false || _canDoAction == false)
                return;
            
            _characterMovement.DoMove();
        }

        private void OnCharacterDie()
        {
            _animator.SetTrigger("Die");
        }

        public void StopActions()
        {
            _canDoAction = false;
        }
    }
}