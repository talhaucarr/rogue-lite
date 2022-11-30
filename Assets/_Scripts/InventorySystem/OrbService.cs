using System;
using System.Collections.Generic;
using _Scripts.GameCore.Player;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    public class OrbService : Service<OrbService>
    {
       /*
        *This service needs to be changed to a Stack 
        */

        private List<Orb> _orbs = new List<Orb>();
        private float _radius = 15f;

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

        private void Update()
        {
            CheckCollecteableOrbs();
        }

        public void RegisterOrb(Orb orb)
        {
            _orbs.Add(orb);
        }
        
        public void UnregisterOrb(Orb orb)
        {
            _orbs.Remove(orb);
        }
        
        private void CheckCollecteableOrbs()
        {
            if(_orbs.Count == 0) return;

            foreach (var orb in _orbs)
            {
                if(!orb.IsCollecteable) continue;
                
                if (Vector3.Distance(orb.transform.position, PlayerManager.Instance.transform.position) < _radius)
                {
                    orb.Collect();
                }
            }
        }
    }
}
