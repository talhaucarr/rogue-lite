using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.StatSystem
{
    [CreateAssetMenu(fileName = "New Stat", menuName = "ScriptableObjects/StatSystem/Stat")]
    public class StatSettings : ScriptableObject
    {
        [Header("Stat Definitions")]
        [SerializeField] private StatToFloatDictionary stats;

        [NonSerialized]
        private StatToFloatDictionary _runtimeStats = new StatToFloatDictionary();

        [SerializeField] private StatToFloatDictionary StatMonitor; 
        
        private StatToFloatDictionary StatsDictionary
        {
            get
            {
                if (_runtimeStats.Count == 0)
                {
                    _runtimeStats.CopyFrom(stats);
                    StatMonitor = _runtimeStats;
                }
                return _runtimeStats;
            }
        }

        public float GetStat(StatKey key)
        {
            if (StatsDictionary.TryGetValue(key, out var value))
                return value;
            Debug.LogWarning(name + $" cant find stat: '{key}'");
            return -1;
        }

        public bool TryAddStat(StatKey statKey, float value)
        {
            return StatsDictionary.TryAdd(statKey, value);
        }

        public bool HasStat(StatKey statKey)
        {
            return StatsDictionary.ContainsKey(statKey);
        }

        public void MultiplyStat(StatKey statKey, float multiplier)
        {
            #if UNITY_EDITOR
            if(!StatsDictionary.ContainsKey(statKey))
                Debug.LogWarning(name + $" tried Multipling stat '{statKey}' that doesnt exist !");
            #endif
            
            StatsDictionary[statKey] *= multiplier;
        }
    }
}
