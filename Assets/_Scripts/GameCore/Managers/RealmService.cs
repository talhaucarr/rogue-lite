using System.Collections.Generic;
using _Scripts.RealmSystem;
using UnityEngine;
using Utilities;

namespace _Scripts.GameCore.Managers
{
    public class RealmService : Service<RealmService>
    {
        [SerializeField] private List<RealmData> realms = new List<RealmData>();
        
        internal override void Init()
        {
        }

        internal override void Begin()
        {
            SetReady();
        }

        internal override void Dispose()
        {
        }
        
        public RealmData GetRealmData(string realmName)
        {
            return realms.Find(realm => realm.realmName == realmName);
        }
    }
}
