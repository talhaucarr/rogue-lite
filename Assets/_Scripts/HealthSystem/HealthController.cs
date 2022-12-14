using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Scripts.HealthSystem
{
    public abstract class HealthController : MonoBehaviour, IDamagable, IComparable
    {
        #region SerializeFields

        [BHeader("General")]
        [SerializeField] private Image hpBar;
        
        #endregion

        #region Properties
        
        public UnityEvent onDeath { get; } = new();
        public UnityEvent onHit { get; } = new();

        #endregion

        #region Public Variables

        public float CurrentHealth { get; private set; }
        public bool IsAlive { get; set; } = true;
        public Transform Transform => transform;

        #endregion

        #region Private Variables

        private float _maxHealth;
        private HpSlider hpSlider;

        #endregion

        #region Protected Methods
        

        #endregion

        #region Abstract Methods

        protected abstract void Die();

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
        

        #endregion

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            HealthController otherHealthController = obj as HealthController;
            if (otherHealthController != null)
                return this.CurrentHealth.CompareTo(otherHealthController.CurrentHealth);
            else
                throw new ArgumentException("Object is not a HealthController");
        }
    }
}
