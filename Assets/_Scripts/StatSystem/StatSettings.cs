using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.StatSystem
{
    [CreateAssetMenu(fileName = "New Stat", menuName = "ScriptableObjects/StatSystem/Stat")]
    public class StatSettings : ScriptableObject
    {
        #region Serialized Fields

        [Header("General Stats")]
        [SerializeField] private float damage;
        [SerializeField] private float health;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float movementSpeed;
        
        [Header("Stat Definitions")]
        [SerializeField] private List<Stat> extraStats;

        #endregion

        #region Properties

        public float Damage => damage;
        public float Health => health;
        public float AttackRange => attackRange;
        public float AttackSpeed => attackSpeed;
        public float MovementSpeed => movementSpeed;
        public List<Stat> ExtraStats => extraStats;

        #endregion

        #region Private Methods

        public Stat GetStat(StatKey key)
        {
            foreach (var stat in extraStats)
            {
                if (stat.StatKey == key)
                {
                    return stat;
                }
            }
            Debug.LogError("Cant find stat!");
            return null;
        }

        #endregion
        
    }
}
