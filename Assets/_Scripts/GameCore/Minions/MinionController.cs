using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.AnimationSystem;
using _Scripts.GameCore.AttackSystem.Enums;
using _Scripts.GameCore.Minions;
using _Scripts.GameCore.Player;
using _Scripts.HealthSystem;
using _Scripts.InventorySystem;
using _Scripts.ItemSystem;
using _Scripts.MovementSystem;
using _Scripts.StatSystem;
using UnityEngine;

public abstract class MinionController : MonoBehaviour, IEntityController
{

    #region Serialized Fields
    
    [BHeader("Master")]
    [SerializeField] private PlayerController minionMaster;
    [SerializeField] private MinionType minionType;
    
    [BHeader("Modules")]
    [SerializeField] private MinionMovementModule _movementModule;
    
    [BHeader("General")]
    [SerializeField] protected StatSettings _statSettings;
    [SerializeField] protected MinionItem _minionItem;
    [SerializeField] protected float masterStandRadius;

    [BHeader("VFX")]
    [SerializeField] private GameObject _trailVFX;
    
    #endregion

    #region Properties

    public Transform Transform => transform;
    public StatSettings StatSettings => _statSettings;
    public MinionItem MinionItem => _minionItem;

    #endregion

    #region Private Fields

    private AnimationController _animationController;

    #endregion

    #region Unity Methods
    
    private Vector3 lookPos;
    private Camera _camera;

    private void Start()
    {
        CreateAttackByType();
        _animationController = GetComponent<AnimationController>();
        
        _movementModule.Setup(_animationController);

        _camera = CameraManager.Instance.Camera;
    }

    private void Update()
    {
        MoveToMaster();
        LookAtMaster();
    }
    
    #endregion

    #region Abstract Methods

    protected abstract void CreateAttackByType();

    #endregion
    
    #region Public Methods
    
    protected virtual void SetTrailVFX(bool active)
    {
        if(_trailVFX) _trailVFX.SetActive(active);
    }

    #endregion

    #region Private Methods
    
    
    private void LookAtMaster()
    {
        transform.LookAt(minionMaster.transform, Vector3.up);
    }

    private void MoveToMaster()
    {
        Vector3 distanceDif = minionMaster.transform.position - transform.position;
        Vector3 moveDir;
        float speedMultiplierForDistance;
        if(distanceDif.magnitude < masterStandRadius)
        {
            moveDir = Vector3.zero;
            speedMultiplierForDistance = 1;
            SetTrailVFX(false);
        }
        else
        {
            speedMultiplierForDistance = Mathf.Pow(distanceDif.magnitude, 2);
            moveDir = new Vector3(distanceDif.x, distanceDif.z, 0).normalized;   
            SetTrailVFX(true);
        }
        _movementModule.MoveDirection(transform, moveDir, _statSettings.GetStat(StatKey.MoveSpeed) * speedMultiplierForDistance);
    }

    #endregion
}
