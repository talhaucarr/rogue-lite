using System;
using _Scripts.AnimationSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public class AttackController : MonoBehaviour, IAttackController
    {
        #region Serialized Fields

        [BHeader("Attack Settings")]
        
        [SerializeField] private AttackBase _attackBase;
        
        [BHeader("References")]
        [SerializeField] private AnimationController _animationController;

        #endregion
        
        #region Public Fields


        #endregion

        #region Private Fields

        private StatSettings _statSettings;
        private AttackData _attackData;

        private bool _canAttack = true;
        
        private float _attackTimer = 0;
        private float _attackSpeed;

        #endregion

        #region Unity Methods
        
        private void FixedUpdate()
        {
            _attackTimer += Time.fixedDeltaTime;
            if (_attackTimer >= (20f / (1 + _attackSpeed)))
            {
                _canAttack = true;
            }
        }

        #endregion

        #region Public Methods

        public void Setup(StatSettings statSettings)
        {
            _statSettings = statSettings;
            _attackData = new AttackData(transform);
            _attackSpeed = statSettings.AttackSpeed;
            _attackBase = Instantiate(_attackBase);
            _attackBase.SetupOrUpdate(statSettings);
        }

        public void Attack()
        {
            if(!_attackBase.Attack(_attackData)) return;
            if(!_canAttack) return;

            _canAttack = false;
            _attackTimer = 0;
            _animationController.AttackAnim();
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
