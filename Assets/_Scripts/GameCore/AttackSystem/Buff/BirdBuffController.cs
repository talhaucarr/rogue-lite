using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Buff
{
    public class BirdBuffController : MonoBehaviour, IBuff
    {
        private StatSettings _statSettings;
        
        public void Setup(StatSettings stats)
        {
            _statSettings = stats;    
        }

        public void AddBuff()
        {
            
        }
    }
}
