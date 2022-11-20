using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.RealmSystem
{
    [CreateAssetMenu(fileName = "New Realm Data", menuName = "ScriptableObjects/RealmSystem/RealmData")]
    public class RealmData : ScriptableObject
    {
        [BHeader("General")]
        public string realmName;
        public string realmDescription;
        public bool harderBetterFasterStronger;
        
        [BHeader("Realm Enemies")]
        public List<RealmEnemyData> realmEnemies = new List<RealmEnemyData>();
    }
    
    [Serializable]
    public class RealmEnemyData
    {
        public string enemyName;
        public int spawnWeight;
        public GameObject enemyPrefab;
    }
}
