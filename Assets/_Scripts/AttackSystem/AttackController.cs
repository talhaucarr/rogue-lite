using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public class AttackController : MonoBehaviour, IAttackController
    {
        #region Serialized Fields

        [BHeader("Attack Settings")]
        
        [SerializeField] private AttackBase _attackBase;

        #endregion
        
        #region Public Fields


        #endregion

        #region Private Fields

        private StatSettings _statSettings;
        private AttackData _attackData;

        #endregion

        #region Unity Methods

        

        #endregion

        #region Public Methods

        public void Setup(StatSettings statSettings)
        {
            _statSettings = statSettings;
            _attackData = new AttackData(transform);
            _attackBase.SetupOrUpdate(statSettings);
        }

        public void Attack()
        {
            if(!_attackBase.Attack(_attackData)) return;
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
