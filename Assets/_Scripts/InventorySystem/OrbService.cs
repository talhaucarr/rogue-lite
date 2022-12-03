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
        private LinkedList<Orb> _orbs = new LinkedList<Orb>();

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
            //CheckCollecteableOrbs();
        }

        public void RegisterOrb(Orb orb)
        {
            _orbs.AddLast(orb);
        }
        
        public void UnregisterOrb(Orb orb)
        {
            _orbs.Remove(orb);
        }
        
    }
}
