using System.Collections;
using System.Collections.Generic;
using _Scripts.MovementSystem;
using UnityEngine;

public class MinionMovementModule : MonoBehaviour, IMovementModule
{
    #region Private Variables
    
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

    public void MoveDirection(Transform transform, Vector3 direction, float movementSpeed)
    {
        if (direction == Vector3.zero)
        {
            _animationController.SetWalking(false, 1);
            return;
        }

        _animationController.SetWalking(true, movementSpeed);
        var moveDirection = new Vector3(direction.x, 0, direction.y) * movementSpeed;
            
        transform.position += (moveDirection * Time.deltaTime);
    }

    public void MovePosition(Transform transform, Vector3 position, float movementSpeed)
    {
        //
    }

    #endregion
}
