using _Scripts.StatSystem;

namespace _Scripts.GameCore.AttackSystem.Interfaceses
{
    public interface IBuff
    {
        public void Setup(StatSettings stats);
        public void AddBuff();
    }
}
