using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private LayerMask _layerMaskGround;

        private const int MoveMouseButton = 1;

        public void Update()
        {
            if (Input.GetMouseButtonDown(MoveMouseButton))
            {
                if (_character.IsLife == false) return;

                Ray ray = GetRayFromScreen();

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMaskGround))
                {
                    _character.SetDestination(hit.point);
                }
            }
        }

        private Ray GetRayFromScreen() => Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
