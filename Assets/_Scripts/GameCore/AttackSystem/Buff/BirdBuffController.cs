using System;
using _Scripts.GameCore.AttackSystem.Classes;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.Player;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Buff
{
    public class BirdBuffController : MonoBehaviour, IBuff
    {
        [BHeader("VFX")]
        [SerializeField] private GameObject buffVFX;
        
        private StatSettings _statSettings;
        
        public void Setup(StatSettings stats)
        {
            _statSettings = stats;
            AddBuff();
        }

        public void AddBuff()
        {
            BirdBuff buff = new BirdBuff(_statSettings.GetStat(StatKey.BirdLightningDamage).StatValue);
            PlayerManager.Instance.PlayerBuffController.AddBuff(buff);
            CreateBuffVFX();
        }
        
        private void CreateBuffVFX()
        {
            if(buffVFX)
                PlayerManager.Instance.PlayerVFXController.CreateVFX(buffVFX);
        }
    }
    
    [Serializable]
    public class BirdBuff : BuffData
    {
        public BirdBuff(float value) : base(value)
        {
            
        }

        public override void ApplyBuff()
        {
            Debug.Log($"Apply buff VFX");
        }

        public override void RemoveBuff()
        {
            throw new System.NotImplementedException();
        }
    }
}
