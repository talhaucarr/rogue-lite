using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.RealmSystem
{
    [CreateAssetMenu(fileName = "New Realm Data", menuName = "ScriptableObjects/RealmSystem/RealmData")]
    public class RealmData : ScriptableObject
    {
        public string realmName;
        public string realmDescription;
        public Sprite realmIcon;
        public Sprite realmBackground;
        public List<RealmEnemyData> realmEnemies = new List<RealmEnemyData>();
    }
    
    [Serializable]
    public class RealmEnemyData
    {
        public string enemyName;
        public int priority;
        public GameObject enemyPrefab;
    }
}