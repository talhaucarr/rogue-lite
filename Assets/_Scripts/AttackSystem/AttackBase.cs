using System;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public abstract class AttackBase : ScriptableObject
    {
        #region Serialized Fields
        

        #endregion
        
        #region Protected Variables
        
        [NonSerialized] protected StatSettings _stats;

        #endregion

        #region Abstract Methods
        public virtual void SetupOrUpdate(StatSettings stats)
        {
            _stats = stats;
        }
        
        public abstract bool Attack(AttackData attackData);

        
        #endregion

        #region Virtual Methods
        
        #endregion
    }
    
    public struct AttackData
    {
        public Transform myTransform;
        
        public AttackData(Transform myTransform)
        {
            this.myTransform = myTransform;
        }
    }
}
