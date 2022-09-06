using _Scripts.StatSystem;
using _Scripts.WeaponSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public class AttackController : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Attack Settings")]
        
        [SerializeField] private AttackBase _attackBase;
        [SerializeField] private Weapon _weapon;

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
            _attackBase.Attack(new AttackData(_weapon.Damage, _weapon.Range, transform));
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
