using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    public class OrbService : Service<OrbService>
    {
        private List<Orb> _orbs = new List<Orb>();

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
        
        public void RegisterOrb(Orb orb)
        {
            _orbs.Add(orb);
        }
        
        public void UnregisterOrb(Orb orb)
        {
            _orbs.Remove(orb);
        }
        
        public void CollectOrbsInRadius(Vector3 position, float radius)
        {
            if(_orbs.Count == 0) return;
            var orbClone = new List<Orb>(_orbs);
            
            foreach (var orb in orbClone)
            {
                if(!orb.IsCollecteable) continue;
                if (Vector3.Distance(orb.transform.position, position) < radius)
                {
                    orb.Collect();
                }
            }
        }
    }
}
