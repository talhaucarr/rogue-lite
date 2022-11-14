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
    public class EnemyController : MonoBehaviour, IEntityController
    {

        #region Serialized Fields
        [BHeader("Stat Settings")]
        [SerializeField] private StatSettings _statSettings;
    
        [BHeader("Modules")]
        [SerializeField] private MinionMovementModule _movementModule;
        #endregion

        #region Properties

        public Transform Transform => transform;
        public StatSettings StatSettings => _statSettings;

        #endregion

        #region Private Fields
    
        private IAttack _attack;
        private HealthController _healthController;
        private AnimationController _animationController;

        #endregion

        #region Unity Methods
    
        private Vector3 lookPos;
        private Camera _camera;

        private void Start()
        {
            EnemyManager.Instance.RegisterEnemy(this);
            _attack = GetComponent<IAttack>();
            _animationController = GetComponent<AnimationController>();
            _healthController = GetComponent<HealthController>();
        
            _healthController.Setup(_statSettings.GetStat(StatKey.Health));
            _healthController.onDeath.AddListener(OnDeath);
            _movementModule.Setup(_animationController);
            _attack.Setup(_statSettings);

            _camera = CameraManager.Instance.Camera;
        }

        private void Update()
        {
            MoveToPlayer();
            LookAtPlayer();
        }
    
        #endregion
    
        #region Public Methods
    
    

        #endregion

        #region Private Methods

        private void OnDeath()
        {
            EnemyManager.Instance.UnRegisterEnemy(this);
        }
    
        private void LookAtPlayer()
        {
            transform.LookAt(PlayerManager.Instance.transform, Vector3.up);
        }

        private void MoveToPlayer()
        {
            Vector3 distanceDif = PlayerManager.Instance.transform.position - transform.position;
            Vector3 moveDir = new Vector3(distanceDif.x, distanceDif.z, 0).normalized;
            _movementModule.MoveDirection(transform, moveDir, _statSettings.GetStat(StatKey.MoveSpeed));
        }

        #endregion
    }
}
