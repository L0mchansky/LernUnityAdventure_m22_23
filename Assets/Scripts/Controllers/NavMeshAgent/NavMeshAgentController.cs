using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23
{
    public abstract class NavMeshAgentController : Controller
    {
        protected NavMeshAgent _agent;

        public void AddNavMeshAgentComponent(Character character, float speed, float angularSpeed, float acceleration)
        {
            if (character.gameObject.TryGetComponent(out NavMeshAgent agent))
            {
                _agent = agent;
                return;
            }

            _agent = character.gameObject.AddComponent<NavMeshAgent>();
            _agent.speed = speed;
            _agent.angularSpeed = angularSpeed;
            _agent.acceleration = acceleration;
        }

        public Vector3 GetDestination() => _agent.destination;

        public void SetDestination(Character character, Vector3 destination)
        {
            _agent.destination = destination;
            character.SetDestination(destination);
        }

        public void SetVelocity(Character character)
        {
            character.SetVelocity(_agent.velocity);
        }
    }
}