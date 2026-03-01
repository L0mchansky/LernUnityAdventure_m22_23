using UnityEngine;
using LernUnityAdventure_m24_25;

namespace LernUnityAdventure_m22_23
{
    public class Character : MonoBehaviour, IDamageable, IExplodable, IHealable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private CharacterView _characterView;

        private ComponentHealth _componentHealth;
        private bool _isWalking;
        private Vector3 _destination;
        private Vector3 _velocity;
        private const float VelocityMagnitudeThreshold = 0.05f;

        public ComponentHealth ComponentHealth => _componentHealth;
        public bool IsLife => _componentHealth.IsLife;
        public bool IsWalking => _isWalking;
        public Vector3 Destination => _destination;
        public Vector3 Velocity => _velocity;

        public void Awake()
        {
            _componentHealth = new ComponentHealth(_maxHealth);
        }

        public void Update()
        {
            OnWalking();
        }

        public void SetDestination(Vector3 value)
        {
            _destination = value;
        }

        public void SetVelocity(Vector3 value)
        {
            _velocity = value;
        }

        public void TakeDamage(float damage, ComponentHealth health)
        {
            float newHealth = health.CurrentHealth - damage;
            health.SetHealth(newHealth);

            _characterView.PlayTakeDamage();
        }

        public void OnExplode(ExplosionData data)
        {
            TakeDamage(data.Damage, _componentHealth);
        }
        private void OnWalking()
        {
            if (_velocity.magnitude >= VelocityMagnitudeThreshold)
            {
                _isWalking = true;
            }
            else
            {
                _isWalking = false;
            }
        }

        public void OnHealing(float healingValue, ComponentHealth componentHealth)
        {
            float newHealth = componentHealth.CurrentHealth + healingValue;
            componentHealth.SetHealth(newHealth);
        }
    }
}
