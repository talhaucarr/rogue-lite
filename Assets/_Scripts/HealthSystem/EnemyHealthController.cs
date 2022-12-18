using _Scripts.Events;
using _Scripts.GameCore.Enemies;
using UnityEngine;

namespace _Scripts.HealthSystem
{
    public class EnemyHealthController : HealthController
    {
        private EnemyDiedEvent _enemyDiedEvent;
        
        #region Overrides of HealthController
        
        protected override void Die()
        {
            IsAlive = false;
            onDeath?.Invoke();
            if(gameObject.activeSelf) Destroy(gameObject);//TODO Replace with object pool
        }

        #endregion
    }
}
