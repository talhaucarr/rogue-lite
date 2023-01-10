using System.Collections.Generic;
using _Scripts.GameCore.Minions;
using UnityEngine;

namespace _Scripts.GameCore.Player
{
    public class PlayerMinionService : Service<PlayerMinionService>
    {
        [SerializeField] private List<MinionController> minionController;
        
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

        public void Subscribe(MinionController minion)
        {
            minionController.Add(minion);
        }
        
        public void Unsubscribe(MinionController minion)
        {
            minionController.Remove(minion);
        }

        public void LevelUpMinion(MinionController minion)
        {
            minion.LevelUp();
        }
        
        
    }
}
