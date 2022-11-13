using _Scripts.InventorySystem;
using UnityEngine;
using Utilities;

namespace _Scripts.GameCore.Player
{
    public class PlayerManager : AutoSingleton<PlayerManager>//TODO Gokayla konuş.
    {
        [BHeader("Controllers")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private PlayerBuffController playerBuffController;
        
        public PlayerBuffController PlayerBuffController => playerBuffController;
        public PlayerController PlayerController => playerController;
        public InventoryController InventoryController => inventoryController;
    }
}
