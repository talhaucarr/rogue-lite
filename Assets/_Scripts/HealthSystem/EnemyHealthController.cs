using UnityEngine;

namespace _Scripts.HealthSystem
{
    public class EnemyHealthController : HealthController
    {
        private EnemyDiedEvent _enemyDiedEvent;
        
        #region Overrides of HealthController
        
        protected override void Die()
        {
            _enemyDiedEvent.Fire(gameObject);
            Destroy(gameObject);//TODO Replace with object pool
        }

        #endregion
    }
}
