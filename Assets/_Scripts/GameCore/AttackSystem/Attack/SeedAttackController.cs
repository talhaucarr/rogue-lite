using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.AttackSystem.Projectiles;
using _Scripts.GameCore.Enemies;
using _Scripts.HealthSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Attack
{
    public class SeedAttackController : AutoAttackController
    {
        public override bool Attack()
        {
            if(!EnemyManager.Instance.GetClosestEnemyInRange(transform.position, _statSettings.GetStat(StatKey.AttackRange), out var enemy)) return false;
            if (!enemy.Transform.TryGetComponent<IDamagable>(out var damagable)) return false;
            var projectile = Instantiate(attackPrefab, transform.position, Quaternion.identity);//TODO replace with pool
            projectile.GetComponent<IProjectile>().Setup(enemy.Transform, 20, _statSettings.GetStat(StatKey.Damage));
            return true;
        }
    }
}
