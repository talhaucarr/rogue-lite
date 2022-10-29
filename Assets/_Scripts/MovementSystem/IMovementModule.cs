using _Scripts.AnimationSystem;
using UnityEngine;

namespace _Scripts.MovementSystem
{
    public interface IMovementModule
    {
        void Setup(AnimationController animationController);
        void MoveDirection(Transform transform, Vector3 direction, float movementSpeed);
        void MovePosition(Transform transform, Vector3 position, float movementSpeed);
    }
}
