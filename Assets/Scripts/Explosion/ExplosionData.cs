using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    public struct ExplosionData
    {
        private Vector3 _position;
        private float _force;
        private float _radius;
        private float _damage;

        public ExplosionData(Vector3 position, float force, float radius) : this()
        {
            _position = position;
            _force = force;
            _radius = radius;
        }

        public ExplosionData(Vector3 position, float force, float radius, float damage)
        {
            _position = position;
            _force = force;
            _radius = radius;
            _damage = damage;
        }

        public Vector3 Position => _position;
        public float Force => _force;
        public float Radius => _radius;
        public float Damage => _damage;
    }
}
