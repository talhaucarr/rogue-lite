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
        [SerializeField] private float attackSpeed;
        [SerializeField] private float movementSpeed;
        
        [Header("Stat Definitions")]
        [SerializeField] private List<StatDefinition> statDefinitions;

        #endregion

        #region Properties

        public float Damage => damage;
        public float Health => health;
        public float AttackSpeed => attackSpeed;
        public float MovementSpeed => movementSpeed;
        public List<StatDefinition> StatDefinitions => statDefinitions;

        #endregion

        #region Private Methods

        public float GetStatValue(string statName)
        {
            foreach (var statDefinition in statDefinitions)
            {
                if (statDefinition.StatName == statName)
                {
                    return statDefinition.StatValue;
                }
            }
            Debug.LogError("Cant find stat!");
            return 0;
        }

        #endregion
        
    }
}
