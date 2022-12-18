using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.AttackSystem.Projectiles;
using _Scripts.HealthSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Attack
{
    public class PhantomAttackController : AutoAttackController
    {
        public override bool Attack()
        {
            var canAttack = _enemyService.GetClosestEnemyInRange(transform.position, _statSettings.GetStat(StatKey.AttackRange), out var damagable);
            if (!canAttack) return false; 
            
            var aoe = Instantiate(attackPrefab, damagable.Transform.position, Quaternion.identity);//TODO replace with pool
            aoe.GetComponent<AreaDamage>().Setup(0.25f, 100, 5, 5,damagable.Damagable);
            
            return true;
        }
    }
}
