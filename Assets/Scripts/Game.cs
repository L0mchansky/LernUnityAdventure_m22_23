using UnityEngine;
using UnityEngine.AI;

namespace LernUnityAdventure_m22_23
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private LayerMask _layerMaskGround;
        [SerializeField] private GameObject _flagPrefab;

        private const int MoveMouseButton = 1;
        private const float RangeToDeactivateFlag = 1f;

        private GameObject _flagGround;

        public void Awake()
        {
            _flagGround = Instantiate(_flagPrefab);
            _flagGround.SetActive(false);
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(MoveMouseButton))
            {
                if (_character.IsLife == false) return;

                Ray ray = GetRayFromScreen();

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMaskGround))
                {
                    if (_character.SetDestination(hit.point))
                    {
                        Vector3 flagPosition = new Vector3(hit.point.x, _flagGround.transform.position.y, hit.point.z);
                        _flagGround.transform.position = flagPosition;
                        _flagGround.SetActive(true);
                    }
                }
            }

            if (_flagGround != null && _character.transform != null)
            {
                float distanceToFlag = (_character.transform.position - _flagGround.transform.position).magnitude;

                if (distanceToFlag <= RangeToDeactivateFlag)
                {
                    _flagGround.SetActive(false);
                }
            }
        }

        private Ray GetRayFromScreen() => Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
