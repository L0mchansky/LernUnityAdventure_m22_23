using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class CharacterView : MonoBehaviour
    {
        private static readonly int _isWalkingKey = Animator.StringToHash("IsWalking");
        private static readonly int _takeDamageKey = Animator.StringToHash("TakeDamage");
        private static readonly int _dieKey = Animator.StringToHash("Die");
        private static readonly string _injuredLayerName = "Injured Layer";

        private const float InjuredHealthPercentThreshold = 30f;
        private const float VelocityMagnitudeThreshold = 0.05f;

        [SerializeField] private Character _character;

        private Animator _animator;
        private ComponentHealth _health;
        private bool _isPlayedInjure = false;
        private bool _isPlayedDie = false;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
            _health = _character.Health;
        }

        public void Update()
        {
            if (_character.CurrentVelocity.magnitude >= VelocityMagnitudeThreshold)
            {
                StartWalking();
            }
            else
            {
                StopWalking();
            }

            if (_isPlayedInjure == false && _health.PercentageHealth <= InjuredHealthPercentThreshold)
            {
                PlayInjured();
            }

            if (_isPlayedDie == false && _health.IsLife == false)
            {
                PlayDie();
            }
        }

        private void StopWalking()
        {
            _animator.SetBool(_isWalkingKey, false);
        }

        private void StartWalking()
        {
            _animator.SetBool(_isWalkingKey, true);
        }

        public void PlayTakeDamage()
        {
            _animator.SetTrigger(_takeDamageKey);
        }

        public void PlayInjured()
        {
            _isPlayedInjure = true;
            int injuredLayerIndex = _animator.GetLayerIndex(_injuredLayerName);
            _animator.SetLayerWeight(injuredLayerIndex, 1);
        }

        public void PlayDie()
        {
            _isPlayedDie = true;
            _animator.SetTrigger(_dieKey);
        }
    }
}
