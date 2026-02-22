using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class ComponentHealth
    {
        private float _maxHealth;
        private float _currentHealth;
        private float _procentageHealth;
        private bool _isLife = true;

        public ComponentHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _procentageHealth = 100f;
        }

        public void SetHealth(float newHealth)
        {
            if (newHealth <= 0)
            {
                _currentHealth = 0;
                _procentageHealth = 0;
                _isLife = false;
            }
            else if (newHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
                _procentageHealth = 100f;
            } 
            else
            {
                _currentHealth = newHealth;
                _procentageHealth = CalcProcentage();
            }
        }

        private float CalcProcentage()
        {
            return 100f / _maxHealth * _currentHealth;
        }

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;
        public bool IsLife => _isLife;
        public float ProcentageHealth => _procentageHealth;
    }
}
