using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

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
    }
}
