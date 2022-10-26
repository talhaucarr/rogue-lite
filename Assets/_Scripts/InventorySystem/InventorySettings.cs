using UnityEngine;

namespace _Scripts.InventorySystem
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "ScriptableObjects/InventorySystem/InventorySettings")]
    public class InventorySettings : ScriptableObject
    {
        [SerializeField] private int _inventorySize;
        [SerializeField] private int _minionSize;
        
        public int InventorySize => _inventorySize;
        public int MinionSize => _minionSize;
    }
}
