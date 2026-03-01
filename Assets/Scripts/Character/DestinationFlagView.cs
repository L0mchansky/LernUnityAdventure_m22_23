using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class DestinationFlagView: MonoBehaviour
    {
        [SerializeField] Character _character;
        [SerializeField] GameObject _flagView;

        private const float RangeToDeactivateFlag = 0.5f;

        public void Update()
        {
            Vector3 destination = _character.GetDestination();

            if (destination != null && NierToFlag(destination) == false)
            {
                SetDestinationFlag(destination);
            } 
            else
            {
                _flagView.SetActive(false);
            }

        }

        public void SetDestinationFlag(Vector3 destination)
        {
            Vector3 flagPosition = new Vector3(destination.x, transform.position.y, destination.z);
            transform.position = flagPosition;
            _flagView.SetActive(true);
        }

        public bool NierToFlag(Vector3 point)
        {
            float distanceToFlag = (_character.transform.position - point).magnitude;

            if (distanceToFlag <= RangeToDeactivateFlag)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
