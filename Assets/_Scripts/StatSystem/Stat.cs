using UnityEngine;

namespace _Scripts.StatSystem
{
    [CreateAssetMenu(fileName = "Stat Definition", menuName = "ScriptableObjects/StatSystem/StatDefinition")]
    public class Stat : ScriptableObject
    {
        [Header("General")]
        [SerializeField] private StatKey statKey;
        [SerializeField] private float statValue;
        
        [Header("Display")]
        [SerializeField] private string displayName;
        [SerializeField] private string description;

        public StatKey StatKey => statKey;
        public float StatValue => statValue;
        public string DisplayName => displayName;
        public string Description => description;
    }

    public enum StatKey
    {
        // player stat keys 1-100
        PlayerDashDistance = 1,
        PlayerDashSpeed = 2,

        // seedling minion 101-200
        SeedlingRootDuration = 101,
        BirdLightningDamage = 102,
        
    }
}
