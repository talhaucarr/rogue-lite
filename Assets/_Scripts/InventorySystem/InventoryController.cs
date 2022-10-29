using System;
using System.Collections.Generic;
using _Scripts.ItemSystem;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        #region Serialized Fields
        [BHeader("Inventory Settings")]
        [SerializeField] private InventorySettings inventorySettings;

        [BHeader("Inventory Slots")] 
        [SerializeField] private int Currency;
        [SerializeField] private List<ItemSlot> itemSlots;
        
        [BHeader("Game Events")]
        [SerializeField] private UnityEvent onAddItem;
        [SerializeField] private UnityEvent onRemoveItem;
        
        #endregion

        #region Private Fields
        

        #endregion

        #region Public Fields
        
        
        #endregion

        #region Unity Methods

        private void Start()
        {
           
        }

        #endregion

        #region Public Methods
        

        public void AddItem(MinionItem minionItem)
        {
            if(itemSlots.Count >= inventorySettings.InventorySize)
                return;
            
            if(IsItemInInventory(minionItem)) return;
            
            itemSlots.Add(new ItemSlot(minionItem, 1));
            onAddItem?.Invoke();
        }

        public void RemoveItem(MinionItem minionItem)
        {
            var itemSlot = GetItemSlotByItem(minionItem);
            if (itemSlot == null) return;
            
            itemSlot.Amount--;
            itemSlots.Remove(itemSlot);
            onRemoveItem?.Invoke();
        }
        
        public int GetCurrency()
        {
            return Currency;
        }
        
        public void AddCurrency(int amount)
        {
            Currency += amount;
        }
        
        public void RemoveCurrency(int amount)
        {
            if(Currency - amount < 0)
                Currency = 0;
            else
                Currency -= amount;
        }

        #endregion

        #region Private Methods
        
        private ItemSlot GetItemSlotByItem(Item item)
        {
            return itemSlots.Find(x => x.Item == item);
        }
        
        private bool IsItemInInventory(Item item)
        {
            return itemSlots.Exists(x => x.Item == item);
        }

        #endregion
    }
}
