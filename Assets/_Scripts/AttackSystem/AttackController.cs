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

        #endregion

        #region Unity Methods

        

        #endregion

        #region Public Methods

        public void Setup(StatSettings statSettings)
        {
            _statSettings = statSettings;
            
        }

        public void Attack()
        {
            _attackBase.Attack(_statSettings, transform);
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
