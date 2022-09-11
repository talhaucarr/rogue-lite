using UnityEngine;

namespace _Scripts.MovementSystem
{
    public interface IMovementModule
    {
        void Setup(AnimationController animationController);
        void MoveDirection(Vector3 direction, float movementSpeed);
        void MovePosition(Vector3 position, float movementSpeed);
    }
}
