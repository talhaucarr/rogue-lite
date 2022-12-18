using System;
using _Scripts.HealthSystem;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Projectiles
{
    public class AreaDamage : MonoBehaviour
    {
        private float _damage;
        private float _radius;
        private float _duration;
        private int _maxTargets;
        private IDamagable _closestEnemy;
        
        public void Setup(float duration, float damage, float radius, int maxTargets, IDamagable closestEnemy = null)
        {
            _damage = damage;
            _radius = radius;
            _duration = duration;
            _maxTargets = maxTargets;

            DOVirtual.DelayedCall(_duration, OverlapAndDamage);
            Destroy(gameObject, _duration * 4);//TODO replace with pool
        }
        
        private void OverlapAndDamage()
        {
            Collider[] colliders = new Collider[_maxTargets];
            Physics.OverlapSphereNonAlloc(transform.position, _radius, colliders);
            foreach (var enemyCollider in colliders)
            {
                if (enemyCollider == null) continue;
                if (enemyCollider.TryGetComponent(out IDamagable enemy))
                {
                    enemy.DealDamage(_damage);
                }
            }
        }
    }
}
