using UnityEngine;

namespace _Scripts.HealthSystem
{
    public class EnemyHealthController : HealthController
    {
        #region Overrides of HealthController
        
        protected override void Die()
        {
            onDeath?.Invoke();
            Destroy(gameObject);//TODO Replace with object pool
        }

        #endregion
    }
}
