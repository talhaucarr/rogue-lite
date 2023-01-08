using System;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Classes
{
    [Serializable]
    public abstract class BuffData
    {
        protected float _buffValue;

        protected BuffData(float value)
        {
            _buffValue = value;
        }
        
        public abstract void ApplyBuff();
        public abstract void RemoveBuff();
    }
}
