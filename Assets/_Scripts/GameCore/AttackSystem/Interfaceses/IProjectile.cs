using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Interfaceses
{
    public interface IProjectile
    {
        public void Setup(Transform target, float speed, float damage);
    }
}
