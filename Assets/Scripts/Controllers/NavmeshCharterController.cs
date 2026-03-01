using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class NavmeshCharterController : Controller
    {
        private const string LayerMaskName = "WalkGround";
        private LayerMask _layerMaskGround;

        private const int MoveMouseButton = 1;
        private Character _character;
        private Game _game;

        public NavmeshCharterController(Character character, Game game)
        {
            _layerMaskGround = LayerMask.GetMask(LayerMaskName);
            _character = character;
            _game = game;
        }

        protected override void UpdateLogic(float deltatime)
        {
            if (Input.GetMouseButtonDown(MoveMouseButton))
            {
                if (_character.IsLife == false) return;

                Ray ray = _game.GetRayFromScreen();

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMaskGround))
                {
                    _character.SetDestination(hit.point);
                }
            }
        }
    }
}
