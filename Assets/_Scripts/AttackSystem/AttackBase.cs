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
        
        protected AttackData _attackData;
        
        
        #endregion

        #region Abstract Methods
        
        
        #endregion

        #region Virtual Methods
        
        public virtual void Attack(AttackData attackData)
        {
            _attackData = attackData;

            switch (attackType)
            {
                case AttackType.Ranged:
                    RangedAttack();
                    break;
                case AttackType.Melee:
                    break;
                case AttackType.Kamikaze:
                    break;
            }
        }

        protected virtual void RangedAttack()
        {
            
        }

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
