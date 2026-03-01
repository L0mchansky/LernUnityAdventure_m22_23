using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class NavMeshCharacterController : NavMeshAgentController
    {
        private const string LayerMaskName = "WalkGround";
        private const int MoveMouseButton = 1;

        private readonly LayerMask _layerMaskGround;
        private readonly Character _character;
        private readonly Game _game;

        public NavMeshCharacterController(Character character, Game game, float speed, float angularSpeed, float acceleration)
        {
            AddNavMeshAgentComponent(character, speed, angularSpeed, acceleration);

            _layerMaskGround = LayerMask.GetMask(LayerMaskName);
            _character = character;
            _game = game;

            SetDestination(_character, _character.transform.position);
        }

        protected override void UpdateLogic(float deltatime)
        {
            SetVelocity(_character);

            if (Input.GetMouseButtonDown(MoveMouseButton))
            {
                if (_character.IsLife == false) return;

                Ray ray = _game.GetRayFromScreen();

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMaskGround))
                {
                    SetDestination(_character, hit.point);
                }
            }
        }
    }
}
