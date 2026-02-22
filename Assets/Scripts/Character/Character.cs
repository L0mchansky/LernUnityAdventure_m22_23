using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _characterMaxHealth;

        private NavMeshAgent _agent;
        private ComponentHealth _health;

        public void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _health = new ComponentHealth(_characterMaxHealth);
        }

        public bool SetDestination(Vector3 targetPoint) => _agent.SetDestination(targetPoint);

        public Vector3 CurrentVelosity => _agent.velocity;

        public ComponentHealth Health => _health;

        public bool IsLife => _health.IsLife;
    }
}
