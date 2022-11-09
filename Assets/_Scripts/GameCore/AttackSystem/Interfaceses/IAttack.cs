using _Scripts.StatSystem;

namespace _Scripts.GameCore.AttackSystem.Interfaceses
{
    public interface IAttack
    {
        public void Setup(StatSettings stats);
        public bool Attack();
    }
}
