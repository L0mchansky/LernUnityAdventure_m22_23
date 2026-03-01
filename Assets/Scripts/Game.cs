using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private NavmeshCharterController _characterController;

        private void Awake()
        {
            _characterController = new NavmeshCharterController(_character, this);
            _characterController.Enable();
        }

        public void Update()
        {
            _characterController.Update(Time.deltaTime);
        }

        public Ray GetRayFromScreen() => Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
