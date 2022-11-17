using _Scripts.AnimationSystem;
using _Scripts.MovementSystem;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.GameCore.Minions
{
    public class MinionMovementModule : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        private AnimationController _animationController;

        #endregion

        #region Unity Methods

        private void Start()
        {
        }

        #endregion
        
        #region Public Methods

        public void Setup(AnimationController animationController)
        {
            _animationController = animationController;
        }

        public void MoveDirection(Vector3 direction, float movementSpeed)
        {
            if (direction == Vector3.zero)
            {
                _animationController.SetWalking(false, 1);
                return;
            }
            Debug.Log($"aga");
            _animationController.SetWalking(true, movementSpeed);
            var moveDirection = new Vector3(direction.x, 0, direction.y);

            _navMeshAgent.SetDestination(moveDirection);
        }

        #endregion
    }
}
