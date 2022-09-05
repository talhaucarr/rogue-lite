using UnityEngine;

namespace _Scripts.StatSystem
{
    [CreateAssetMenu(fileName = "Stat Definition", menuName = "ScriptableObjects/StatSystem/StatDefinition")]
    public class StatDefinition : ScriptableObject
    {
        [Header("General")]
        [SerializeField] private string statName;
        [SerializeField] private float statValue;
        
        [Header("Display")]
        [SerializeField] private string displayName;
        [SerializeField] private string description;

        public string StatName => statName;
        public float StatValue => statValue;
        public string DisplayName => displayName;
        public string Description => description;
    }
}
