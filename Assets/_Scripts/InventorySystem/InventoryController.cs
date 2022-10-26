using System;
using System.Collections.Generic;
using _Scripts.ItemSystem;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        #region Serialized Fields
        [BHeader("Inventory Settings")]
        [SerializeField] private InventorySettings inventorySettings;
        
        [BHeader("Inventory Slots")]
        [SerializeField] private List<ItemSlot> itemSlots;
        
        #endregion

        #region Private Fields
        
        

        #endregion

        #region Public Fields
        

        #endregion

        #region Unity Methods

        #endregion

        #region Public Methods
        

        public void AddItem(MinionItem item)
        {
            if(itemSlots.Count >= inventorySettings.InventorySize)
                return;
            
            var itemSlot = GetItemSlotByItem(item);
            if (itemSlot != null)
            {
                itemSlot.Amount++;
            }
            else
            {
                itemSlots.Add(new ItemSlot(item, 1));
            }
        }

        public void RemoveItem(MinionItem item)
        {
            var itemSlot = GetItemSlotByItem(item);
            if (itemSlot == null) return;
            
            itemSlot.Amount--;
            if (itemSlot.Amount <= 0)
            {
                itemSlots.Remove(itemSlot);
            }
        }

        #endregion

        #region Private Methods
        
        private ItemSlot GetItemSlotByItem(Item item)
        {
            return itemSlots.Find(x => x.Item == item);
        }

        #endregion
    }
}
