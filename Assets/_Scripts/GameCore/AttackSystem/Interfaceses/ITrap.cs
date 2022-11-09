using _Scripts.StatSystem;

namespace _Scripts.GameCore.AttackSystem.Interfaceses
{
    public interface ITrap
    {
        public void Setup(StatSettings stats);
        public bool Trap();
    }
}
