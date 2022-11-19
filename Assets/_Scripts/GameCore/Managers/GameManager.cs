using System.Collections.Generic;
using _Scripts.RealmSystem;
using UnityEngine;
using Utilities;

namespace _Scripts.GameCore.Managers
{
    public class GameManager : AutoSingleton<GameManager>
    {
        [SerializeField] private List<RealmData> realms = new List<RealmData>();
        
        public RealmData GetRealmData(string realmName)
        {
            return realms.Find(realm => realm.realmName == realmName);
        }
    }
}
