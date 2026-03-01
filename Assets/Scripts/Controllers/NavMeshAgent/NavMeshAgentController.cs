using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23
{
    public abstract class NavMeshAgentController : Controller
    {
        protected NavMeshAgent _agent;

        public void AddNavMeshAgentComponent(Character character)
        {
            _agent = character.gameObject.AddComponent<NavMeshAgent>();
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