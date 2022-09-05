using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.InputSystem
{
    public class InputController : MonoBehaviour, CharacterInput.IPlayerActions
    {
        #region Properties

        public Vector2 MovementValue { get; private set; }

        #endregion

        #region Private Variables

        private CharacterInput _controls;

        #endregion

        #region Unity Methods

        private void Start()
        {
            _controls = new CharacterInput();
            _controls.Player.SetCallbacks(this);
            _controls.Player.Enable();
        }

        private void OnDestroy()
        {
            _controls.Player.Disable();
        }

        #endregion

        #region Input Actions

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            
        }

        #endregion

    }
}
