using _Scripts.AnimationSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    public class AutoAttackController : MonoBehaviour, IAttackController
    {
        [BHeader("Attack Type")]
        [SerializeField] private string attackName;
        [SerializeField] private AttackType attackType;
        
        [BHeader("Attack SO")]
        [SerializeField] private AttackBase _attackBase;
        
        [BHeader("References")]
        [SerializeField] private AnimationController _animationController;
        
        private AttackData _attackData;
        private StatSettings _statSettings;
        private float _attackTimer = 0;
        private float _attackSpeed; // duration = 20 / 3 + attackSpeed

        public void Setup(StatSettings statSettings)
        {
            _statSettings = statSettings;
            _attackData = new AttackData(transform);
            _attackSpeed = statSettings.AttackSpeed;
            _attackBase = Instantiate(_attackBase);
            _attackBase.SetupOrUpdate(statSettings);
        }

        private void FixedUpdate()
        {
            _attackTimer += Time.fixedDeltaTime;
            if (_attackTimer >= (20f / (1 + _attackSpeed)))
            {
                Attack();
            }
        }

        private void Attack()
        {
            if(!_attackBase.Attack(_attackData)) return;
            _animationController.CastSpell();
            _attackTimer = 0;
        }
    }
}
