using _Scripts.AnimationSystem;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem
{
    public class PlayerAttackController : MonoBehaviour, IAttack
    {
        #region Serialized Fields

        [BHeader("References")]
        [SerializeField] private AnimationController _animationController;

        #endregion
        
        #region Public Fields


        #endregion

        #region Private Fields

        private StatSettings _statSettings;

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
            _attackSpeed = statSettings.AttackSpeed;
        }

        public bool Attack()
        {
            //if(!_attackBase.Attack(_attackData)) return;
            if(!_canAttack) return false;

            _canAttack = false;
            _attackTimer = 0;
            _animationController.AttackAnim();
            return true;
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
