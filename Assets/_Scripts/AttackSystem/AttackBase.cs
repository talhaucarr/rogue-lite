using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public abstract class AttackBase : ScriptableObject
    {
        #region Serialized Fields
        
        [SerializeField] protected AttackType attackType = AttackType.Ranged;

        #endregion
        
        #region Protected Variables

        protected Transform _playerTransform;
        protected StatSettings _statSettings;
        
        #endregion

        #region Abstract Methods
        
        
        #endregion

        #region Virtual Methods
        
        public virtual void Attack(StatSettings settings, Transform target)
        {
            _playerTransform = target;
            _statSettings = settings;

            switch (attackType)
            {
                case AttackType.Ranged:
                    RangedAttack(_statSettings, _playerTransform.position);
                    break;
                case AttackType.Melee:
                    break;
                case AttackType.Kamikaze:
                    break;
            }
        }

        protected virtual void RangedAttack(StatSettings settings, Vector3 target)
        {
            
        }

        #endregion
    }
}
