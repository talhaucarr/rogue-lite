using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.Minions;
using UnityEngine;

namespace _Scripts.GameCore.MinionControllers
{
    public class PhantomController : MinionController
    {
        private IAttack _attack;
        protected override void CreateAttackByType()
        {
            _attack = GetComponent<IAttack>();
            _attack.Setup(_statSettings);
        }
    }
}
