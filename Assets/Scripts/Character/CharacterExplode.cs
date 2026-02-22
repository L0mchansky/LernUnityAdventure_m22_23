using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class CharacterExplode : MonoBehaviour, IExplodable
    {
        public void OnExplode(ExplosionData data, Collider collider)
        {
            if (collider.TryGetComponent(out IDamage characterDamage) == false) return;
            if (collider.TryGetComponent(out Character character) == false) return;

            characterDamage.TakeDamage(data.Damage, character.Health);
        }
    }
}
