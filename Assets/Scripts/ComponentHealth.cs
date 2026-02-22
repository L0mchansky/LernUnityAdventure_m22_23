using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class ComponentHealth
    {
        private float _maxHealth;
        private float _currentHealth;
        private bool _isLife = true;

        public ComponentHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void SetHealth(float newHealth)
        {
            if (newHealth <= 0)
            {
                _currentHealth = 0;
                _isLife = false;
            }
            else if (newHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            } 
            else
            {
                _currentHealth = newHealth;
            }
        }

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;
        public bool IsLife => _isLife;
    }
}
