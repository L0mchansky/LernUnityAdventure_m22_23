using System;
using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class CharacterView : MonoBehaviour
    {
        private readonly int IsWalkingKey = Animator.StringToHash("IsWalking");
        private readonly int TakeDamageKey = Animator.StringToHash("TakeDamage");
        private readonly int DieKey = Animator.StringToHash("Die");
        private readonly String InjuredLayerName = "Injured Layer";

        [SerializeField] private Character _character;
        private Animator _animator;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            if (_character.CurrentVelosity.magnitude >= 0.05f)
            {
                StartWalking();
            }
            else
            {
                StopWalking();
            }
        }

        private void StopWalking()
        {
           _animator.SetBool(IsWalkingKey, false);
        }

        private void StartWalking()
        {
            _animator.SetBool(IsWalkingKey, true);
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(TakeDamageKey);
        }

        public void Injured()
        {
            int injuredLayerIndex = _animator.GetLayerIndex(InjuredLayerName);
            _animator.SetLayerWeight(injuredLayerIndex, 1);
        }

        public void Die() {
            _animator.SetTrigger(DieKey);
        }
    }
}
