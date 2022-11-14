using _Scripts.AnimationSystem;
using _Scripts.GameCore.AttackSystem;
using _Scripts.HealthSystem;
using _Scripts.InputSystem;
using _Scripts.MovementSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.Player
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        #region Serialized Fields
        
        [BHeader("Stats")]
        [SerializeField] private StatSettings _statSettings;

        [BHeader("Modules")]
        [SerializeField] private MovementModule _movementModule;

        #endregion

        #region Properties
        public Transform Transform => transform;
        public StatSettings StatSettings => _statSettings;

        #endregion

        #region Private Fields
        
        private InputModule _inputModule;
        private HealthController _healthController;
        private PlayerAttackController _playerAttackController;
        private AnimationController _animationController;

        #endregion

        #region Unity Methods
        
        private Vector3 lookPos;
        private Camera _camera;

        private void Start()
        {
            _inputModule = GetComponent<InputModule>();
            _playerAttackController = GetComponent<PlayerAttackController>();
            _healthController = GetComponent<HealthController>();
            _animationController = GetComponent<AnimationController>();
            
            _movementModule.Setup(_animationController);
            _healthController.Setup(_statSettings.Health);
            _playerAttackController.Setup(_statSettings);

            _camera = CameraManager.Instance.Camera;
        }

        private void Update()
        {
            Move();
            LookMousePosition();
            if (_inputModule.IsAttacking)
            {
                _playerAttackController.Attack();
            }
        }
        
        #endregion
        
        #region Public Methods
        
        

        #endregion

        #region Private Methods
        
        
        private void LookMousePosition()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100))
            {
                lookPos = hit.point;
            }

            var playerTransform = transform.position;
            
            Vector3 lookDir = lookPos - playerTransform;
            lookDir.y = 0;

            transform.LookAt(playerTransform + lookDir, Vector3.up);
        }

        private void Move()
        {
            var transform1 = transform;
            
            var forward = transform1.forward;
            var right = transform1.right;
            var movementDirection = _inputModule.MovementValue;

            var forwardMovement = forward * movementDirection.y;
            var rightMovement = right * movementDirection.x;

            var movement = forwardMovement + rightMovement;
            movement.Normalize();
            _movementModule.MoveDirection(transform, new Vector2(movement.x, movement.z), _statSettings.MovementSpeed);
        }

        #endregion
        
    }
}
