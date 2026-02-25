using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23
{
    public class Character : MonoBehaviour, IDamageable, IExplodable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private CharacterView _characterView;

        private NavMeshAgent _agent;
        private ComponentHealth _health;

        public Vector3 CurrentVelocity => _agent.velocity;
        public ComponentHealth Health => _health;
        public bool IsLife => _health.IsLife;

        public void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _health = new ComponentHealth(_maxHealth);
        }

        public bool SetDestination(Vector3 targetPoint)
        {
            return _agent.SetDestination(targetPoint);
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
    }
}
