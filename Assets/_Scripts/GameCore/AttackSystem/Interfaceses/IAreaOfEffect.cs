using System.Collections.Generic;
using _Scripts.HealthSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Interfaceses
{
    public interface IAreaOfEffect
    {
        public void Setup(float duration, float damage);
    }
}
