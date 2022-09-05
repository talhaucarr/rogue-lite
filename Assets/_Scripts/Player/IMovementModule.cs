using UnityEngine;

namespace _Scripts.Character
{
    public interface IMovementModule
    {
        void Move(Vector3 direction, float movementSpeed);
        void MoveDoTween(Vector3 direction, float movementSpeed);
    }
}
