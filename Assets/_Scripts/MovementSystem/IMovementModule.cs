using UnityEngine;

namespace _Scripts.MovementSystem
{
    public interface IMovementModule
    {
        void MoveDirection(Transform transform, Vector3 direction, float movementSpeed);
        void MovePosition(Transform transform, Vector3 position, float movementSpeed);
    }
}
