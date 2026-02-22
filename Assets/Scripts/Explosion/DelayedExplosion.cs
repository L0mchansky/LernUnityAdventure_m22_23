using System;
using UnityEngine;

namespace LernUnityAdventure_m22_23
{
    [RequireComponent(typeof(SphereCollider))]
    public class DelayedExplosion: MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _force;
        [SerializeField] private float _radiusExplosion;
        [SerializeField] private float _radiusActivation;
        [SerializeField] private float _countdownToExplosion;
        [SerializeField] private GameObject _particlePrefab;

        private const float RATIO_SPEED_TO_TIME = 10f;

        private float _currentTimeToExplosion;

        private bool _isExplodes = false;

        public void Awake()
        {
            if(TryGetComponent(out SphereCollider collider))
            {
                collider.radius = _radiusActivation;
            }
        }

        public void Update()
        {
            if (_isExplodes == false) return;

            _currentTimeToExplosion -= Time.deltaTime;

            if (_currentTimeToExplosion <= 0)
            {
                VFXExplose();
                Explose();
                _isExplodes = false;
                Destroy(gameObject);
            } 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isExplodes) return;

            _isExplodes = true;
            _currentTimeToExplosion = _countdownToExplosion;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radiusExplosion);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radiusActivation);
        }

        private void Explose()
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, _radiusExplosion);

            ExplosionData data = new ExplosionData(transform.position, _force, _radiusExplosion, _damage);

            foreach (Collider target in targets)
            {
                if (target.TryGetComponent(out IExplodable explodable) == false)
                    continue;

                explodable.OnExplode(data, target);
            }
        }

        private void VFXExplose()
        {
            GameObject particleSystemObj = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = particleSystemObj.GetComponent<ParticleSystem>();

            float lifeTime = Mathf.Sqrt(_radiusExplosion / RATIO_SPEED_TO_TIME);
            float speed = Mathf.Sqrt(_radiusExplosion * RATIO_SPEED_TO_TIME);

            particleSystem.startLifetime = lifeTime;
            particleSystem.startSpeed = speed;

            particleSystemObj.SetActive(true);
        }
    }
}
