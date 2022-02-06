using System;
using UnityEngine;

namespace Code.Character
{
    public class CharacterHealth : MonoBehaviour, ITakeHit
    {
        private bool _canTakeDamage;
        private int _currentHealth;

        private bool _isAlive;
        public event Action OnDied = delegate {  };
        
        public bool CanTakeHit => _canTakeDamage && _isAlive;
        public bool IsAlive => _isAlive;

        public void TakeHit(int damage)
        {
            if(_isAlive == false)
                return;
            
            if(_canTakeDamage == false)
                return;
            
            ModifyHealth(damage);
        }

        public void Configure(int maxHealth, bool canTakeDamage)
        {
            _currentHealth = maxHealth;
            _canTakeDamage = canTakeDamage;
            _isAlive = true;
        }

        public void UpdateStatus(bool canTakeDamage)
        {
            _canTakeDamage = canTakeDamage;
        }
        private void ModifyHealth(int amount)
        {
            _currentHealth -= amount;
            
            if (_currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            _isAlive = false;
            OnDied();
        }
    }
}