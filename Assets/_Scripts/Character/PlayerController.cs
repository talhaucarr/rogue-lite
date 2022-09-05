using System;
using _Scripts.InputSystem;
using UnityEngine;

namespace _Scripts.Character
{
    [RequireComponent(typeof(MovementModule))]
    public class PlayerController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private CharacterSettings _characterSettings;

        #endregion

        #region Properties

        public CharacterSettings CharacterSettings => _characterSettings;

        #endregion

        #region Private Fields

        private IMovementModule _movementModule;
        private InputController _inputController;

        #endregion

        #region Unity Methods

        private void Start()
        {
            _movementModule = GetComponent<IMovementModule>();
            _inputController = GetComponent<InputController>();
        }

        private void Update()
        {
            Move();
        }

        #endregion
        
        #region Public Methods
        
        

        #endregion

        #region Private Methods

        private void Move()
        {
            _movementModule.Move(_inputController.MovementValue, _characterSettings.MovementSpeed);
        }

        #endregion
        
    }
}
