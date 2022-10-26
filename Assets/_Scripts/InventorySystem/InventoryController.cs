using System;
using System.Collections.Generic;
using _Scripts.ItemSystem;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        #region Serialized Fields
        
        [SerializeField] private InventorySettings _inventorySettings;

        #endregion

        #region Private Fields
        
        private List<ItemSlot> _itemSlots;

        #endregion

        #region Public Fields
        

        #endregion

        #region Unity Methods

        #endregion

        #region Public Methods
        

        public void AddItem(MinionItem item)
        {
            if(_itemSlots.Count >= _inventorySettings.InventorySize)
                return;
            
            var itemSlot = GetItemSlotByItem(item);
            if (itemSlot != null)
            {
                itemSlot.Amount++;
            }
            else
            {
                _itemSlots.Add(new ItemSlot(item, 1));
            }
        }

        public void RemoveItem(MinionItem item)
        {
            var itemSlot = GetItemSlotByItem(item);
            if (itemSlot == null) return;
            
            itemSlot.Amount--;
            if (itemSlot.Amount <= 0)
            {
                _itemSlots.Remove(itemSlot);
            }
        }

        #endregion

        #region Private Methods
        
        private ItemSlot GetItemSlotByItem(Item item)
        {
            return _itemSlots.Find(x => x.Item == item);
        }

        #endregion
    }
}
