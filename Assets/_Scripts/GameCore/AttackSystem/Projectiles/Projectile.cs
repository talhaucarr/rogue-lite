using System;
using System.Collections;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.HealthSystem;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField] private GameObject hit;
        [SerializeField] private GameObject flash;
        
        private float _speed;
        private float _damage;
        private Tween _projectileMoveTween;
        private Tween _projectileKillTween;
        private Vector3 _projectileMoveDir;
        
        public void Setup(Transform target, float speed, float damage)
        {
            _speed = speed;
            _damage = damage;
            _projectileMoveDir = (target.position - transform.position).normalized;
            CreateFlashEffect();
            MoveWithDoTween(target);
        }
        
        private void CreateHitEffect(Transform target)
        {
            var hitEffect = Instantiate(hit, target.position, Quaternion.identity);//TODO replace with pool
            Destroy(hitEffect, 0.1f);//TODO replace with pool
        }
        
        private void CreateFlashEffect()
        {
            var flashEffect = Instantiate(flash, transform.position, Quaternion.identity);//TODO replace with pool
            Destroy(flashEffect, 0.2f);//TODO replace with pool
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            var enemy = collision.transform.GetComponent<IDamagable>();
            enemy?.DealDamage(_damage);
            CreateHitEffect(collision.transform);
            Destroy(gameObject);//TODO replace with pool
            _projectileKillTween?.Kill();
            _projectileMoveTween?.Kill();
        }
        
        private void MoveWithDoTween(Transform target)
        {
            _projectileKillTween = DOVirtual.DelayedCall(2, KillProjectile);
            
            _projectileMoveTween = transform.DOMove(transform.position + _projectileMoveDir * 50, 2).SetEase(Ease.Linear).OnComplete(() =>
            {
                CreateHitEffect(target);
            });
        }
        
        private void KillProjectile()
        {
            if(gameObject.activeSelf) Destroy(gameObject);//TODO replace with pool
            _projectileMoveTween?.Kill();
        }

        private IEnumerator Move(Transform target)
        {
            while (target != null)
            {
                var dir = target.position - transform.position;
                var distanceThisFrame = _speed * Time.deltaTime;
                transform.Translate(dir.normalized * distanceThisFrame);
                yield return null;
            }
        }
    }
}
