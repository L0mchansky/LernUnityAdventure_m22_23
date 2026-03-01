using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _character;

        [SerializeField] private float _speed;
        [SerializeField] private float _angularSpeed;
        [SerializeField] private float _acceleration;

        [SerializeField] private float _patrolRadius;
        [SerializeField] private float _arrivalThreshold;
        [SerializeField] private float _retryDelayAfterFail;

        private NavMeshCharacterController _navmeshCharacterController;
        //private BoredomPatrolController _boredomPatrolController;

        private void Awake()
        {
            _navmeshCharacterController = new NavMeshCharacterController(_character, this, _speed, _angularSpeed, _acceleration);
            //_boredomPatrolController = new BoredomPatrolController(_character, _patrolRadius, _arrivalThreshold, _retryDelayAfterFail);
            _navmeshCharacterController.Enable();
            //_boredomPatrolController.Enable();
        }

        public void Update()
        {
            //TODO: Логика переключения между состояниями
            _navmeshCharacterController.Update(Time.deltaTime);
        }

        public Ray GetRayFromScreen() => Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
