using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class CharacterDamage : MonoBehaviour, IDamage
    {
        private const float InjuredHealthPercentThreshold = 30f;

        public void TakeDamage(float damage, ComponentHealth health)
        {
            float newHealth = health.CurrentHealth - damage;
            health.SetHealth(newHealth);

            CharacterView characterView = GetComponentInChildren<CharacterView>();

            if (characterView == null) return;

            characterView.PlayTakeDamage();

            if (health.PercentageHealth <= InjuredHealthPercentThreshold)
            {
                characterView.PlayInjured();
            }

            if (health.IsLife == false)
            {
                characterView.PlayDie();
            }
        }
    }
}
