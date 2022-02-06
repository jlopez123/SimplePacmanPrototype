using Code.Character;
using UnityEngine;

namespace Code.Interactables
{
    public class Coin : Collectible
    {
        [SerializeField] private GameObject _hitParticles;
        [SerializeField] private int _coins;
        protected override void DoCollect(CharacterCoinPurse playerCoinPurse)
        {
            playerCoinPurse.AddCoins(_coins);
            gameObject.SetActive(false);
            
            if(_hitParticles == null)
                return;
            
            Instantiate(_hitParticles, transform.position, Quaternion.identity);
        }
    }
}