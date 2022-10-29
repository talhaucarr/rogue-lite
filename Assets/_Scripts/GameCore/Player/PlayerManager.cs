using _Scripts.InventorySystem;
using UnityEngine;
using Utilities;

namespace _Scripts.GameCore.Player
{
    public class PlayerManager : AutoSingleton<PlayerManager>//TODO Gokayla konuş.
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private InventoryController inventoryController;
        
        public PlayerController PlayerController => playerController;
        public InventoryController InventoryController => inventoryController;
    }
}
