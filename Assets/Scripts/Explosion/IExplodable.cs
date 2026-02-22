using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public interface IExplodable
    {
        void OnExplode(ExplosionData data, Collider colider);
    }
}