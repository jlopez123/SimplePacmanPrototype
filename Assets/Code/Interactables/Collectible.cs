using System;
using Code.Character;
using Code.EventQueue;
using UnityEngine;

namespace Code.Interactables
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Collectible : MonoBehaviour
    {
        //--
        public static int RemainingCoins { get; private set; }
        
        //
        public bool IsCollected { get; protected set; }
        public Action OnCollected = delegate {  };

        private void Awake()
        {
            RemainingCoins++;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsCollected)
                return;

            var player = collision.GetComponentInParent<GameUnitController>();
            
            if (player != null)
                Collect(player);
        }

        private void Collect(GameUnitController gameUnit)
        {
            var playerCoinPurse = gameUnit.GetComponent<CharacterCoinPurse>();
            
            if(playerCoinPurse == null)
                return;

            OnCollected();
            DoCollect(playerCoinPurse);
            IsCollected = true;
            
            // --
            RemainingCoins--;
            if(RemainingCoins == 0)
                EventQueueImpl.Instance.EnqueueEvent( new EndGameEventData(true));
        }
        protected abstract void DoCollect(CharacterCoinPurse playerCoinPurse);
    }
}