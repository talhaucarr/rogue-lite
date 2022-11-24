using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.Enemies;
using _Scripts.HealthSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Attack
{
    public class ShadowAttackController : AutoAttackController
    {
        public override bool Attack()
        {
            if(!_enemyService.GetClosestEnemyInRange(transform.position, _statSettings.GetStat(StatKey.AttackRange), out var enemy)) return false;
            if (!enemy.Transform.TryGetComponent<IDamagable>(out var damagable)) return false;
            var aoe = Instantiate(attackPrefab, enemy.Transform.position, Quaternion.identity);//TODO replace with pool
            aoe.GetComponent<IAreaOfEffect>().Setup(5, 50);
            return true;
        }
    }
}
