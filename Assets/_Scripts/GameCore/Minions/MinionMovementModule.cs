using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.GameCore.Minions
{
    public class MinionMovementModule : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private NavMeshAgent _navMeshAgent;

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

        public void MoveDirection(Vector3 direction, float movementSpeed)
        {
            if (direction == Vector3.zero)
            {
                return;
            }
            
            var moveDirection = new Vector3(direction.x, 0, direction.y);
            Vector3 newPosition = transform.position + moveDirection * (movementSpeed * Time.deltaTime);
            bool isValid = NavMesh.SamplePosition(newPosition, out var hitPosition, 1f, NavMesh.AllAreas);
            if (isValid)
            {
                //transform.position = hitPosition.position;
                _navMeshAgent.Warp(newPosition);
                _navMeshAgent.SetDestination(hitPosition.position);
            }

            //_navMeshAgent.Move(moveDirection);
        }

        #endregion
    }
}
