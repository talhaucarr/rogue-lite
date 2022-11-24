using UnityEngine;

namespace _Scripts.HealthSystem
{
    public class PlayerHealthController : HealthController
    {
        private PlayerDeathEvent _playerDeathEvent;
        
        #region Overrides of HealthController

        protected override void Die()
        {
            ResetHealth();
            Destroy(gameObject);//TODO Replace with object pool
        }

        #endregion

        #region Private Methods

        private void GainCurrency()
        {
            //TODO
        }

        #endregion
    }
}
