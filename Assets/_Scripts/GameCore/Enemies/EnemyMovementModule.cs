using UnityEngine;
using UnityEngine.AI;


namespace _Scripts.GameCore.Enemies
{
    public class EnemyMovementModule : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        public void MoveToTarget(Vector3 targetPosition, float movementSpeed)
        {
            if(targetPosition == Vector3.zero)
                return;

            _navMeshAgent.speed = movementSpeed;
            _navMeshAgent.SetDestination(targetPosition);
        }
        
        public void StopMovement()
        {
            _navMeshAgent.speed = 0;
            _navMeshAgent.SetDestination(transform.position);
        }
    }
}
