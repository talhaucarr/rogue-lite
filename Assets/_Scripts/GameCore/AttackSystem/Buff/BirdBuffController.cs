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
            BirdBuff buff = new BirdBuff(_statSettings.GetStat(StatKey.LightningBirdBuffMultiplier));
            PlayerManager.Instance.PlayerBuffController.AddBuff(buff);
            CreateBuffVFX();
        }
        
        private void CreateBuffVFX()
        {
            if(buffVFX)
                PlayerManager.Instance.PlayerVFXController.CreateVFX(buffVFX, new Vector3(0.7f, 0.7f, 0.7f),isAura:true);
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
            PlayerManager.Instance.PlayerController.StatSettings.MultiplyStat(StatKey.MoveSpeed, _buffValue);
        }

        public override void RemoveBuff()
        {
            PlayerManager.Instance.PlayerController.StatSettings.DivideStat(StatKey.MoveSpeed, _buffValue);
        }
    }
}
