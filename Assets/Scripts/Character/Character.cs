using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

namespace LernUnityAdventure_m22_23
{
    public class Character : MonoBehaviour, IDamageable, IExplodable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private CharacterView _characterView;

        private ComponentHealth _health;
        private bool _isWalking;
        private Vector3 _destination;
        private Vector3 _velocity;
        private const float VelocityMagnitudeThreshold = 0.05f;

        public ComponentHealth Health => _health;
        public bool IsLife => _health.IsLife;
        public bool IsWalking => _isWalking;
        public Vector3 Destination => _destination;
        public Vector3 Velocity => _velocity;

        public void Awake()
        {
            _health = new ComponentHealth(_maxHealth);
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

        public void OnExplode(ExplosionData data, Collider collider)
        {
            TakeDamage(data.Damage, _health);
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
    }
}
