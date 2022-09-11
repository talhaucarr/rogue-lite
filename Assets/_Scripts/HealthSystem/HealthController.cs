using System;
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
        public UnityEvent onDeath = new();
        public UnityEvent onHit = new();

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
                onHit.Invoke();
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
            onDeath.Invoke();
            Destroy(gameObject);//TODO Refactor here
        }
        
        #endregion
    }
}
