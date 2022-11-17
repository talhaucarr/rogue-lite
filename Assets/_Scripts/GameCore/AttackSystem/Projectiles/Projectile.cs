using System;
using System.Collections;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.HealthSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField] private GameObject hit;
        [SerializeField] private GameObject flash;
        
        private float _speed;
        private float _damage;
        
        public void Setup(Transform target, float speed, float damage)
        {
            _speed = speed;
            _damage = damage;
            CreateFlashEffect();
            StartCoroutine(Move(target)); 
        }
        
        private void CreateHitEffect(Transform target)
        {
            var hitEffect = Instantiate(hit, target.position, Quaternion.identity);//TODO replace with pool
            Destroy(hitEffect, 1);//TODO replace with pool
        }
        
        private void CreateFlashEffect()
        {
            var flashEffect = Instantiate(flash, transform.position, Quaternion.identity);//TODO replace with pool
            Destroy(flashEffect, 1);//TODO replace with pool
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            var enemy = collision.transform.GetComponent<IDamagable>();
            enemy?.DealDamage(_damage);
            CreateHitEffect(collision.transform);
            Destroy(gameObject);//TODO replace with pool
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
