using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public class AttackController : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Attack Settings")]
        
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
            _attackData = new AttackData(_statSettings.Damage, _statSettings.AttackRange, transform);
        }

        public void Attack()
        {
            _attackBase.Attack(_attackData);
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
