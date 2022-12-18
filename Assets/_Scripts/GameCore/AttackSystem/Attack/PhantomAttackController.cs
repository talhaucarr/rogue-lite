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
            var enemies = _enemyService.GetClosestEnemiesInRange(transform.position, _statSettings.GetStat(StatKey.AttackRange));
            if(enemies.Count == 0) return false;
            
            enemies.Sort();//sort by distance
            var spawnPoint = enemies[0];//get closest enemy
            var aoe = Instantiate(attackPrefab, spawnPoint.Transform.position, Quaternion.identity);//TODO replace with pool
            
            foreach (var enemy in enemies)
            {
                aoe.GetComponent<AreaDamage>().Setup(0.25f, 100, enemy);
            }
            
            return true;
        }
    }
}
