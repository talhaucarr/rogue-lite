using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Scripts.HealthSystem
{
    public class HealthController : MonoBehaviour, IDamagable
    {
        #region SerializeFields
        
        [Header("General")]
        [SerializeField] private Image hpBar;
        
        #endregion

        #region Game Events
        
        [Space(10)]
        [Header("Game Events")]
        [SerializeField] private UnityEvent onEnemyDeath;
        [SerializeField] private UnityEvent onEnemyHit;

        #endregion

        #region Public Variables

        public float CurrentHealth { get; private set; }

        #endregion

        #region Private Variables

        private float _maxHealth;
        private HpSlider hpSlider;

        #endregion
        
        #region Public Methods
        
        public void Setup(float health)
        {
            hpSlider = new HpSlider(hpBar);
            
            _maxHealth = health;
            CurrentHealth = health;
        }

        public void DealDamage(float damage)
        {
            CurrentHealth -= damage;
            hpSlider.SetHp(CurrentHealth / _maxHealth);
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Die();
            }
            else
            {
                onEnemyHit?.Invoke();
            }
        }

        public void ResetHealth()
        {
            CurrentHealth = _maxHealth;
            hpSlider.ResetSlider();
        }

        #endregion

        #region Private Methods

        private void Die()
        {
            ResetHealth();
            onEnemyDeath?.Invoke();
            Destroy(gameObject);//TODO Refactor here
        }
        
        #endregion
    }
}
