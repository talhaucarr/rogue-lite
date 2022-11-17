using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.Minions;
using UnityEngine;

namespace _Scripts.GameCore.MinionControllers
{
    public class BirdController : MinionController
    {
        private IBuff _buff;
        protected override void CreateAttackByType()
        {
            _buff = GetComponent<IBuff>();
            _buff.Setup(_statSettings);
        }
    }
}
