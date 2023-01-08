using UnityEngine;

namespace _Scripts.MovementSystem
{
    [CreateAssetMenu(fileName = "MovementModule", menuName = "ScriptableObjects/Modules/Movement")]
    public class MovementModule : ScriptableObject, IMovementModule
    {
        #region Private Variables
        

        #endregion

        #region Unity Methods

        private void Start()
        {
            
        }

        #endregion
        
        #region Public Methods

        public void Setup()
        {
           
        }

        public void MoveDirection(Transform transform, Vector3 direction, float movementSpeed)
        {
            if (direction == Vector3.zero)
            {
                return;
            }
            
            var moveDirection = new Vector3(direction.x, 0, direction.y) * movementSpeed;
            
            transform.position += moveDirection * Time.deltaTime;
        }

        public void MovePosition(Transform transform, Vector3 position, float movementSpeed)
        {
            //TODO implement do tween
        }

        #endregion

        #region Private Methods
        
        
        #endregion
        
    }
}
