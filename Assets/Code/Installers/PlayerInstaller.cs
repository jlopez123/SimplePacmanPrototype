using Code.Character;
using Code.Character.Input;
using Code.EventQueue;
using UnityEngine;

namespace Code.Installers
{
    public class PlayerInstaller : MonoBehaviour , IEventObserver
    {
        [SerializeField] private GameUnitController _playerCharacter;
        private void Start()
        {
            _playerCharacter.Configure(GetInput(), Vector2.right);
            EventQueueImpl.Instance.Subscribe(EventIds.OnEndGame, this);
        }

        private ICharacterInput GetInput() => new UnityInputAdapter();

        public void SpawnPlayer(Vector2 position)
        {
            //Instantiate() ...
            
            _playerCharacter.gameObject.SetActive(true);
            _playerCharacter.transform.position = position;
            
            EventQueueImpl.Instance.EnqueueEvent(new GameUnitEventData(EventIds.OnLocalPlayerSpawn, _playerCharacter));
            
            _playerCharacter.GetComponent<CharacterHealth>().OnDied += OnPlayerDie;
        }

        private void OnPlayerDie()
        {
            EventQueueImpl.Instance.EnqueueEvent(new EndGameEventData(false));
        }

        public void Process(LocalEventData eventData)
        {
            if(eventData.EventId != EventIds.OnEndGame)
                return;
            
            _playerCharacter.StopActions();
        }
    }
}