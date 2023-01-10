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
        
        [Header("Level Definitions")]
        [SerializeField] private List<StatToFloatDictionary> levelStats;

        [NonSerialized]
        private StatToFloatDictionary _runtimeStats = new StatToFloatDictionary();
        [Space(25)]
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
            Debug.LogError(name + $" cant find stat: '{key}'");
            return -1;
        }
        
        //Levelup Related
        public void ChangeBaseStat(int level)
        {
            if (level > levelStats.Count)
            {
                Debug.LogError(name + $" cant find level: '{level}'");
                return;
            }

            foreach (var levelStat in levelStats[level - 1])
            {
                ChangeStatValue(levelStat.Key, levelStat.Value);
            }
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
                Debug.LogError(name + $" tried Multipling stat '{statKey}' that doesnt exist !");
            #endif
            
            StatsDictionary[statKey] *= multiplier;
        }
        
        public void DivideStat(StatKey statKey, float divisor)
        {
            #if UNITY_EDITOR
            if(!StatsDictionary.ContainsKey(statKey))
                Debug.LogError(name + $" tried Dividing stat '{statKey}' that doesnt exist !");
            #endif
            
            StatsDictionary[statKey] /= divisor;
        }
        
        public void PercentStat(StatKey statKey, float percent)
        {
            #if UNITY_EDITOR
            if(!StatsDictionary.ContainsKey(statKey))
                Debug.LogError(name + $" tried Percenting stat '{statKey}' that doesnt exist !");
            #endif
            
            StatsDictionary[statKey] *= percent / 100;
        }
        
        public void RemovePercentStat(StatKey statKey, float percent)
        {
            #if UNITY_EDITOR
            if(!StatsDictionary.ContainsKey(statKey))
                Debug.LogError(name + $" tried Removing Percent stat '{statKey}' that doesnt exist !");
            #endif
            
            StatsDictionary[statKey] /= percent / 100;
        }
        
        public void ChangeStatValue(StatKey statKey, float value)
        {
            #if UNITY_EDITOR
            if(!StatsDictionary.ContainsKey(statKey))
                Debug.LogError(name + $" tried Changing stat '{statKey}' that doesnt exist !");
            #endif
            
            StatsDictionary[statKey] = value;
        }
    }
}
