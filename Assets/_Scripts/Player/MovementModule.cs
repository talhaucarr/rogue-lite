using UnityEngine;

namespace _Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementModule : MonoBehaviour, IMovementModule
    {
        #region Private Variables

        private CharacterController _characterController;

        #endregion

        #region Unity Methods

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        #endregion
        
        #region Public Methods

        public void Move(Vector3 direction, float movementSpeed)
        {
            if(direction == Vector3.zero)
                return;

            var moveDirection = new Vector3(direction.x, 0, direction.y) * movementSpeed;
            
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        public void MoveDoTween(Vector3 direction, float movementSpeed)
        {
            //TODO implement do tween
        }

        #endregion

        #region Private Methods

        private void FaceMovementDirection(Vector3 movement)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * 10); 
        }

        #endregion
        
    }
}
