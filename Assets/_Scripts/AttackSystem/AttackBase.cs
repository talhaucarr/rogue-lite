using UnityEngine;

namespace _Scripts.AttackSystem
{
    public abstract class AttackBase : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private AttackType attackType = AttackType.Ranged;

        #endregion
        
        #region Public Variables

        
        #endregion

        #region Abstract Methods

        public abstract void Attack(float damage);
        
        #endregion
    }
}
