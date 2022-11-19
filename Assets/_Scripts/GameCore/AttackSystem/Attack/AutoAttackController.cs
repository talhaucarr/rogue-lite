using _Scripts.AnimationSystem;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.Enemies;
using _Scripts.HealthSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Attack
{
    public abstract class AutoAttackController : MonoBehaviour, IAttack
    {
        [BHeader("Attack Type")]
        [SerializeField] protected string attackName;
        [SerializeField] protected GameObject attackPrefab;

        [Space(20)][BHeader("References")]
        [SerializeField] private AnimationController _animationController;
        
        protected StatSettings _statSettings;
        protected float _attackTimer = 0;
        protected float _attackSpeed; // duration = 20 / 3 + attackSpeed
        protected EnemyService _enemyService;

        public void Setup(StatSettings statSettings)
        {
            _enemyService = ServiceProvider.Instance.Get<EnemyService>(gameObject.scene.name);
            _statSettings = statSettings;
            _attackSpeed = statSettings.GetStat(StatKey.AttackSpeed);
        }

        private void FixedUpdate()
        {
            _attackTimer += Time.fixedDeltaTime;
            if (_attackTimer >= (20f / (1 + _attackSpeed)))
            {
                if (!Attack()) return;
                
                _animationController.CastSpell();
                _attackTimer = 0;
            }
        }

        public abstract bool Attack();

    }
}
