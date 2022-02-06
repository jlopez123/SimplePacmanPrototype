using Code.Character;
using Code.EventQueue;
using TMPro;
using UnityEngine;

namespace Code.UI
{  
    [DefaultExecutionOrder(-10)]
    public class UIMainGamePanel : MonoBehaviour, IEventObserver
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        [SerializeField] private UIEndGamePanel _endPanel;


        private void Start()
        {
            EventQueueImpl.Instance.Subscribe(EventIds.OnEndGame, this);
            EventQueueImpl.Instance.Subscribe(EventIds.OnLocalPlayerSpawn, this);
        }

        public void Process(LocalEventData eventData)
        {
            if(eventData.EventId != EventIds.OnEndGame && eventData.EventId != EventIds.OnLocalPlayerSpawn)
                return;
            
            if(eventData.EventId == EventIds.OnEndGame)
            {
                var win = ((EndGameEventData)eventData).Win;
                _endPanel.ShowPanel(win);
                return;
            }

            if (eventData.EventId == EventIds.OnLocalPlayerSpawn)
            {
                var characterPurse =
                    ((GameUnitEventData) eventData).GameUnitController.GetComponent<CharacterCoinPurse>();
                
                characterPurse.OnCoinsChanged += OnPlayerCoinsChanged;
                return;
            }
        }

        private void OnPlayerCoinsChanged(int currentCoins)
        {
            _coinsText.SetText("Points: " + currentCoins);
        }
    }
}