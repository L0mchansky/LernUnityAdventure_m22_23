using System;
using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class CharacterDamage : MonoBehaviour, IDamage
    {
        public void TakeDamage(float damage, ComponentHealth health)
        {
            float newHeatlh = health.CurrentHealth - damage;
            health.SetHealth(newHeatlh);

            CharacterView characterView = GetComponentInChildren<CharacterView>();

            if (characterView == null) return;

            characterView.TakeDamage();

            if (health.IsLife == false) characterView.Die();
        }
    }
}
