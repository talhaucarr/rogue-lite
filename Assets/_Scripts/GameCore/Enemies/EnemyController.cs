using _Scripts.AnimationSystem;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.GameCore.Minions;
using _Scripts.GameCore.Player;
using _Scripts.HealthSystem;
using _Scripts.MovementSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.Enemies
{
    public class EnemyController : MonoBehaviour, IEntityController, IEnemyUpdate
    {

        #region Serialized Fields
        [BHeader("Stat Settings")]
        [SerializeField] private StatSettings _statSettings;
    
        [BHeader("Modules")]
        [SerializeField] private EnemyMovementModule _movementModule;
        #endregion

        #region Properties

        public Transform Transform => transform;
        public StatSettings StatSettings => _statSettings;

        #endregion

        #region Private Fields
    
        private IAttack _attack;
        private HealthController _healthController;
        private Vector3 _targetPosition = Vector3.zero;
        private float _attackRange = 1.2f; //if attack range not set in scriptable object, set it to 1.2f
        private EnemyService _enemyService;
        
        #endregion

        #region Unity Methods
    
        private Vector3 lookPos;

        private void Start()
        {
            _enemyService = ServiceLocator.Instance.Get<EnemyService>();

            _enemyService.RegisterEnemy(this);
            SetHealthController();
            _attackRange = _statSettings.GetStat(StatKey.AttackRange);
        }
        
        #endregion
    
        #region Public Methods
    
        public void EnemyUpdate()
        {
            LookAtPlayer();
            MoveToPlayer();
        }

        #endregion

        #region Private Methods
        
        private void LookAtPlayer()
        {
            transform.LookAt(PlayerManager.Instance.transform, Vector3.up);
        }

        private void MoveToPlayer()
        {
            if (Vector3.Distance(PlayerManager.Instance.transform.position, transform.position) <= _attackRange)
            {
                Attack();
                _movementModule.StopMovement();
                return;
            }

            if (PlayerManager.Instance == null || _targetPosition == PlayerManager.Instance.transform.position) return; //if player is null or target position is the same position, return
            
            _targetPosition = PlayerManager.Instance.transform.position;
            _movementModule.MoveToTarget(_targetPosition, _statSettings.GetStat(StatKey.MoveSpeed));
        }
        
        private void Attack()
        {
            //_attack.Attack();
        }

        private void SetHealthController()
        {
            _healthController = GetComponent<HealthController>();
            _healthController.Setup(_statSettings.GetStat(StatKey.Health));
            _healthController.onDeath.AddListener(OnDeath);
        }

        private void OnDeath()
        {
            _enemyService.UnRegisterEnemy(this);
        }

        #endregion
        
    }
}
