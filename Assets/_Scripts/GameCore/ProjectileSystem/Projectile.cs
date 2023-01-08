using System;
using _Scripts.HealthSystem;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.GameCore.ProjectileSystem
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private GameObject hitEffect;

        private Transform _target;
        private Vector3 _projectileMoveDir;
        private float _speed = 0f;
        private float _damage = 0f;
        
        private Tween _projectileMoveTween;
        private Tween _killTween;

        public void Setup(Transform target, float speed, float damage)
        {
            _target = target;
            _speed = speed;
            _damage = damage;
            _projectileMoveDir = (_target.position - transform.position).normalized;
            StartTween();
        }
        
        private void StartTween()
        {
            _killTween = DOVirtual.DelayedCall(2, KillProjectile);
            _projectileMoveTween = transform.DOMove(transform.position + _projectileMoveDir * _speed, 2f).SetEase(Ease.Linear);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<IDamagable>(out var enemy))
            {
                enemy.DealDamage(_damage);
                CreateHitEffect(enemy.Transform);
            }
            KillProjectile();
        }

        private void KillProjectile()
        {
            if(gameObject.activeSelf) Destroy(gameObject);//TODO replace with pool
            _projectileMoveTween?.Kill();
            _killTween?.Kill();
        }
        
        private void CreateHitEffect(Transform target)
        {
            var effect = Instantiate(hitEffect, target.position, Quaternion.identity);//TODO replace with pool
            Destroy(effect, 0.1f);//TODO replace with pool
        }
    }
}
