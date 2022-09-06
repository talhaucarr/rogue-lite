using UnityEngine;

namespace _Scripts.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObjects/WeaponSystem/Weapon")]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private GameObject weaponPrefab;
        [SerializeField] private float damage;
        [SerializeField] private float range;
        [SerializeField] private float fireRate;
        [SerializeField] private GameObject projectile;
        
        public GameObject WeaponPrefab => weaponPrefab;
        public float Damage => damage;
        public float Range => range;
        public float FireRate => fireRate;
        public GameObject Projectile => projectile;
    }
}
