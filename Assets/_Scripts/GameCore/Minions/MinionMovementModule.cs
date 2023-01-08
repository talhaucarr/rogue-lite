using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.GameCore.Minions
{
    public class MinionMovementModule : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private NavMeshObstacle _navMeshObstacle;

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
                SetComponents(true);
                return;
            }
            
            SetComponents(false);
            
            var moveDirection = new Vector3(direction.x, 0, direction.y);
            Vector3 newPosition = transform.position + moveDirection * (movementSpeed * Time.deltaTime);
            bool isValid = NavMesh.SamplePosition(newPosition, out var hitPosition, 1f, NavMesh.AllAreas);
            if (isValid)
            {
                _navMeshAgent.Warp(newPosition);
                _navMeshAgent.SetDestination(hitPosition.position);
            }
        }

        #endregion

        private void SetComponents(bool active)
        {
            _navMeshAgent.enabled = !active;//Navmesh'in birbirini ittirmesi için bu yapıldı. Daha güzel bi çözüm bul.
            _navMeshObstacle.enabled = active;
        }
    }
}
