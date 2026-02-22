using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23 { 
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _character;

        [SerializeField] private LayerMask _layerMaskGround;

        [SerializeField] private GameObject _flagPrefab;

        private const int MOVE_MOUSE_BUTTON = 1;
        private const float RANGE_TO_DEACTIVE_FLAG = 1f;

        private GameObject _flagGround;

        void Awake()
        {
            _flagGround = GameObject.Instantiate(_flagPrefab);
            _flagGround.SetActive(false);
        }


        void Update()
        {
            if (Input.GetMouseButtonDown(MOVE_MOUSE_BUTTON))
            {
                if (_character.IsLife == false) return;

                Ray ray = GetRayFromScreen();

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMaskGround))
                {
                    if (_character.SetDestination(hit.point))
                    {
                        _flagGround.transform.position = new Vector3(hit.point.x, _flagGround.transform.position.y, hit.point.z);
                        _flagGround.SetActive(true);
                    }
                }
            }

            if (_flagGround != null && _character.transform != null)
            {
                if ((_character.transform.position - _flagGround.transform.position).magnitude <= RANGE_TO_DEACTIVE_FLAG)
                {
                    _flagGround.SetActive(false);
                }
            }
        }

        private Ray GetRayFromScreen() => Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
