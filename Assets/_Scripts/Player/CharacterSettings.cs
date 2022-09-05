using UnityEngine;

namespace _Scripts.Character
{
    [CreateAssetMenu(fileName = "Character Settings", menuName = "ScriptableObjects/CharacterSettings", order = 0)]
    public class CharacterSettings : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private float health;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float movementSpeed;
        
        public float Damage => damage;
        public float Health => health;
        public float AttackSpeed => attackSpeed;
        public float MovementSpeed => movementSpeed;
    }
}