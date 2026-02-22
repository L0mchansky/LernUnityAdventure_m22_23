using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public class CharacterExplode : MonoBehaviour, IExplodable
    {
        public void OnExplode(ExplosionData data, Collider colider)
        {
            if (colider.TryGetComponent(out IDamage characterDamage) == false) return;
            if (colider.TryGetComponent(out Character character) == false) return;

            characterDamage.TakeDamage(data.Damage, character.Health);
        }
    }
}
