using System;

namespace _Scripts.ItemSystem
{
    [Serializable]
    public class ItemSlot
    {
        public MinionItem Item;
        public int Amount;
        
        public ItemSlot(MinionItem item, int amount)
        {
            this.Item = item;
            this.Amount = amount;
        }
    }
}
