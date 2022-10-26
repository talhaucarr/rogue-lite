using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private const string WALKING_KEY = "walking";
    private const string WALKING_SPEED_KEY = "walkingSpeed";
    private const string IDLE_SPEED_KEY = "idleSpeed";
    
    [SerializeField] private Animator animator;
    [BHeader("Settings")] 
    [SerializeField] private float movementSpeedMultiplier;

    [SerializeField] private float idleSpeedMultiplier;

    private void Awake()
    {
        animator.SetFloat(IDLE_SPEED_KEY, idleSpeedMultiplier);
    }

    public void SetWalking(bool isWalking, float moveSpeed)
    {
        animator.SetBool(WALKING_KEY, isWalking);
        animator.SetFloat(WALKING_SPEED_KEY, movementSpeedMultiplier * moveSpeed);
    }
}
