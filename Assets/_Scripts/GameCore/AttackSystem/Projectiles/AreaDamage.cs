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
        
        public void Setup(float duration, float damage, IDamagable enemy)
        {
            _duration = duration;
            _damage = damage;
            
            DOVirtual.DelayedCall(_duration / 4, () => enemy?.DealDamage(_damage));
            
            Destroy(gameObject, _duration);//TODO replace with pool
        }
    }
}
