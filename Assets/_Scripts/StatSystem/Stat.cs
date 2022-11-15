using UnityEngine;

namespace _Scripts.StatSystem
{
    public static class StatHelper
    {
        public static string GetStatDisplayName(StatKey statKey)
        {
            return statKey.ToString();
        }
        
        public static string GetStatDescription(StatKey statKey)
        {
            return statKey + " is a strong stat !";
        }
    }

    public enum StatKey
    {
        Health = 1,
        Damage = 2,
        MoveSpeed = 3,
        AttackSpeed = 4,
        AttackRange = 5,
        LightningBirdBuffMultiplier = 6,
        
        BuffDuration = 101,
        EffectDuration = 102,
    }
}
