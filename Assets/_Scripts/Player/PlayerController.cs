using _Scripts.InputSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(MovementModule))]
    public class PlayerController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private StatSettings _statSettings;

        #endregion

        #region Properties

        public StatSettings StatSettings => _statSettings;

        #endregion

        #region Private Fields

        private IMovementModule _movementModule;
        private InputController _inputController;

        #endregion

        #region Unity Methods
        
        private Vector3 lookPos;
        private Camera _camera;

        private void Start()
        {
            _movementModule = GetComponent<IMovementModule>();
            _inputController = GetComponent<InputController>();
            _camera = Camera.main;
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
            _movementModule.Move(_inputController.MovementValue, _statSettings.MovementSpeed);
        }

        #endregion
        
    }
}
