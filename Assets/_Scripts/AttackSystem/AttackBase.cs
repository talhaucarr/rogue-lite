using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public abstract class AttackBase : ScriptableObject
    {
        #region Serialized Fields
        

        #endregion
        
        #region Protected Variables
        
        protected AttackData _attackData;
        
        
        #endregion

        #region Abstract Methods
        
        
        #endregion

        #region Virtual Methods

        public abstract void Attack(AttackData attackData);

        #endregion
    }
    
    public struct AttackData
    {
        public float damage;
        public float range;
        public Transform target;
        
        public AttackData(float damage, float range, Transform target)
        {
            this.damage = damage;
            this.range = range;
            this.target = target;
        }
    }
}
