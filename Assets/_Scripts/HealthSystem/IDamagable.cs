using UnityEngine;

namespace _Scripts.HealthSystem
{
    public interface IDamagable
    {
        public void DealDamage(float damage);
        public bool IsAlive { get; set; }
        public Transform Transform { get; }
    }
}