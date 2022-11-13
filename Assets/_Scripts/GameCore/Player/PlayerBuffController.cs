using System.Collections.Generic;
using _Scripts.GameCore.AttackSystem.Classes;
using UnityEngine;

namespace _Scripts.GameCore.Player
{
    public class PlayerBuffController : MonoBehaviour
    {
        [SerializeField] private List<BuffData> buffs = new List<BuffData>();
        
        public void AddBuff(BuffData buff)
        {
            buffs.Add(buff);
            buff.ApplyBuff();
        }
        
        public void RemoveBuff(BuffData buff)
        {
            buffs.Remove(buff);
            buff.RemoveBuff();
        }
    }
}
