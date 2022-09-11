using System.Collections;
using System.Collections.Generic;
using _Scripts.MovementSystem;
using UnityEngine;

public class MinionMovementModule : MonoBehaviour, IMovementModule
{
    #region Private Variables

    private CharacterController _characterController;
    private AnimationController _animationController;

    #endregion

    #region Unity Methods

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    #endregion
        
    #region Public Methods

    public void Setup(AnimationController animationController)
    {
        _animationController = animationController;
    }

    public void Move(Vector3 direction, float movementSpeed)
    {
        if (direction == Vector3.zero)
        {
            _animationController.SetWalking(false, 1);
            return;
        }

        _animationController.SetWalking(true, movementSpeed);
        var moveDirection = new Vector3(direction.x, 0, direction.y) * movementSpeed;
            
        _characterController.Move(moveDirection * Time.deltaTime);
    }

    public void MoveDoTween(Vector3 direction, float movementSpeed)
    {
        //
    }

    #endregion
}
