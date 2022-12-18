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
        
        private bool _isStarted;

        public void Setup(float duration, float damage)
        {
            _duration = duration;
            _damage = damage;
            
            Destroy(gameObject, _duration);//TODO replace with pool
        }

        private void OnCollisionStay(Collision collision)
        {
            if(_isStarted) return;
            if(collision.transform.TryGetComponent<IDamagable>(out var enemy))
            {
                _isStarted = true;
                enemy?.DealDamage(_damage);//TODO Add damage type, because it can be player 
                StartCoroutine(BurnDamageRoutine());
            }
        }
        
        private IEnumerator BurnDamageRoutine()
        {
            yield return new WaitForSeconds(_interval);
            _isStarted = false;
        }
    }
}
