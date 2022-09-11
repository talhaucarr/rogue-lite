using UnityEngine;

namespace _Scripts.ItemSystem
{
    public abstract class Item : ScriptableObject
    {
        [Header("Basic Info"), Space(5)]
        [SerializeField] protected  string itemName;
        [SerializeField] protected  string itemDescription;
        [SerializeField] protected  Sprite itemIcon;
        
        [Header("Item Info"), Space(5)]
        [SerializeField] protected int maxStack;
        
        public string ItemName => itemName;
        public string ItemDescription => itemDescription;
        public Sprite ItemIcon => itemIcon;
        public int MaxStack => maxStack;
    }
}
