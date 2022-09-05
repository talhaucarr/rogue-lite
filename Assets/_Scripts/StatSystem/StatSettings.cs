using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.StatSystem
{
    [CreateAssetMenu(fileName = "New Stat", menuName = "ScriptableObjects/StatSystem/Stat")]
    public class StatSettings : ScriptableObject
    {
        [Header("General Stats")]
        [SerializeField] private float damage;
        [SerializeField] private float health;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float movementSpeed;
        
        [Header("Stat Definitions")]
        [SerializeField] private List<StatDefinition> statDefinitions;
        
        public float Damage => damage;
        public float Health => health;
        public float AttackSpeed => attackSpeed;
        public float MovementSpeed => movementSpeed;
        public List<StatDefinition> StatDefinitions => statDefinitions;
        
        public float GetStatValue(string statName)
        {
            foreach (var statDefinition in statDefinitions)
            {
                if (statDefinition.StatName == statName)
                {
                    return statDefinition.StatValue;
                }
            }
            return 0;
        }
    }
}
