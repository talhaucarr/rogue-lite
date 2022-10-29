using UnityEngine;

namespace _Scripts.HealthSystem
{
    public class PlayerHealthController : HealthController
    {
        #region Overrides of HealthController

        protected override void Die()
        {
            ResetHealth();
            onDeath.Invoke();
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
