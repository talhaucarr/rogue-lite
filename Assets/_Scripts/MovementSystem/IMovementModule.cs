using UnityEngine;

namespace _Scripts.MovementSystem
{
    public interface IMovementModule
    {
        void Setup(AnimationController animationController);
        void Move(Vector3 direction, float movementSpeed);
        void MoveDoTween(Vector3 direction, float movementSpeed);
    }
}
