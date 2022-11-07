using System.Collections;
using System.Collections.Generic;
using _Scripts.AnimationSystem;
using _Scripts.AttackSystem;
using _Scripts.AttackSystem.Interfaceses;
using _Scripts.GameCore.Minions;
using _Scripts.GameCore.Player;
using _Scripts.HealthSystem;
using _Scripts.InventorySystem;
using _Scripts.ItemSystem;
using _Scripts.MovementSystem;
using _Scripts.StatSystem;
using UnityEngine;

public class MinionController : MonoBehaviour, IEntityController
{

    #region Serialized Fields
    
    [BHeader("Master")]
    [SerializeField] private PlayerController minionMaster;
    
    [BHeader("Modules")]
    [SerializeField] private MinionMovementModule _movementModule;
    
    [BHeader("General")]
    [SerializeField] private StatSettings _statSettings;
    [SerializeField] private MinionItem _minionItem;
    [SerializeField] private float masterStandRadius;

    [BHeader("VFX")]
    [SerializeField] private GameObject _trailVFX;
    
    #endregion

    #region Properties

    public Transform Transform => transform;
    public StatSettings StatSettings => _statSettings;
    public MinionItem MinionItem => _minionItem;

    #endregion

    #region Private Fields
    
    private IAttackController _attackController;
    private AnimationController _animationController;

    #endregion

    #region Unity Methods
    
    private Vector3 lookPos;
    private Camera _camera;

    private void Start()
    {
        _attackController = GetComponent<IAttackController>();
        _animationController = GetComponent<AnimationController>();
        
        _movementModule.Setup(_animationController);
        _attackController.Setup(_statSettings);

        _camera = CameraManager.Instance.Camera;
        
        //PlayerManager.Instance.GetComponent<InventoryController>().AddMinionToInventory(_minionItem);
    }

    private void Update()
    {
        MoveToMaster();
        LookAtMaster();
    }
    
    #endregion
    
    #region Public Methods
    
    

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
            _trailVFX.SetActive(false);
        }
        else
        {
            speedMultiplierForDistance = Mathf.Pow(distanceDif.magnitude, 2);
            moveDir = new Vector3(distanceDif.x, distanceDif.z, 0).normalized;   
            _trailVFX.SetActive(true);
        }
        _movementModule.MoveDirection(transform, moveDir, _statSettings.MovementSpeed * speedMultiplierForDistance);
    }

    #endregion
}
