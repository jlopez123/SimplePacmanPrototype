using System;
using UnityEngine;

namespace Code.Character
{
    public class CharacterCoinPurse : MonoBehaviour
    {
        public event Action<int> OnCoinsChanged = delegate {  };

        private int _currentCoins;


        public void AddCoins(int coins)
        {
            _currentCoins += coins;
            OnCoinsChanged(_currentCoins);
        }

    }
}