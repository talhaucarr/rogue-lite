using _Scripts.GameCore.AttackSystem.Interfaceses;
using UnityEngine;

namespace _Scripts.GameCore.MinionControllers
{
    public class SeedController : MinionController
    {
        private IAttack _attack;

        protected override void CreateAttackByType()
        {
            _attack = GetComponent<IAttack>();
            _attack.Setup(_statSettings);
        }
    }
}
