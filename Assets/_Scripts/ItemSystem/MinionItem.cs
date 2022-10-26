using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.ItemSystem
{
    [CreateAssetMenu(fileName = "Minion Item", menuName = "ScriptableObjects/ItemSystem/MinionItem")]
    public class MinionItem : Item
    {
        [SerializeField] private List<int> levelUpCosts;
    }
}
