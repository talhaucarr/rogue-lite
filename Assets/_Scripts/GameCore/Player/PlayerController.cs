using _Scripts.AttackSystem;
using _Scripts.HealthSystem;
using _Scripts.InputSystem;
using _Scripts.MovementSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(MovementModule))]
    public class PlayerController : MonoBehaviour, IEntityController
    {
        #region Serialized Fields

        [SerializeField] private StatSettings _statSettings;

        #endregion

        #region Properties
        public Transform Transform => transform;
        public StatSettings StatSettings => _statSettings;

        #endregion

        #region Private Fields

        private IMovementModule _movementModule;
        private InputController _inputController;
        private HealthController _healthController;
        private IAttackController _attackController;
        private AnimationController _animationController;

        #endregion

        #region Unity Methods
        
        private Vector3 lookPos;
        private Camera _camera;

        private void Start()
        {
            _movementModule = GetComponent<IMovementModule>();
            _inputController = GetComponent<InputController>();
            _attackController = GetComponent<AttackController>();
            _healthController = GetComponent<HealthController>();
            _animationController = GetComponent<AnimationController>();
            
            _movementModule.Setup(_animationController);
            _healthController.Setup(_statSettings.Health);
            _attackController.Setup(_statSettings);

            _camera = CameraManager.Instance.Camera;
        }

        private void Update()
        {
            Move();
            LookMousePosition();
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
            var forward = transform.forward;
            var right = transform.right;
            var movementDirection = _inputController.MovementValue;

            var forwardMovement = forward * movementDirection.y;
            var rightMovement = right * movementDirection.x;

            var movement = forwardMovement + rightMovement;
            movement.Normalize();
            _movementModule.MoveDirection(new Vector2(movement.x, movement.z), _statSettings.MovementSpeed);
        }

        #endregion
        
    }
}
