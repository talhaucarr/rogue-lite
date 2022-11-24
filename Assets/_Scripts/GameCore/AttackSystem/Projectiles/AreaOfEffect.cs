using System.Collections;
using System.Collections.Generic;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.HealthSystem;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Projectiles
{
    public class AreaOfEffect : MonoBehaviour, IAreaOfEffect
    {
        private float _damage;
        private float _radius;
        private float _duration;
        
        private const float _interval = 1.2f;

        public void Setup(float duration, float damage)
        {
            _duration = duration;
            _damage = damage;
            
            Destroy(gameObject, _duration);//TODO replace with pool
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent<IDamagable>(out var enemy))
                StartCoroutine(BurnDamageRoutine(enemy));
        }
        
        private IEnumerator BurnDamageRoutine(IDamagable enemy)
        {
            var counter = 0;
            while (counter <= 5)
            {
                yield return new WaitForSeconds(_interval);
                if (!enemy.IsAlive) yield return null;
                
                counter++;
                enemy?.DealDamage(_damage);//TODO Add damage type, because it can be player 
            }

            yield return null;
        }
    }
}
