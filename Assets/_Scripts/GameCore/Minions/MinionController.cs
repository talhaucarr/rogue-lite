using System.Collections;
using System.Collections.Generic;
using _Scripts.AttackSystem;
using _Scripts.HealthSystem;
using _Scripts.InventorySystem;
using _Scripts.ItemSystem;
using _Scripts.MovementSystem;
using _Scripts.Player;
using _Scripts.StatSystem;
using UnityEngine;

public class MinionController : MonoBehaviour, IEntityController
{

    #region Serialized Fields

    [SerializeField] private PlayerController minionMaster;
    [SerializeField] private StatSettings _statSettings;
    [SerializeField] private MinionItem _minionItem;
    [SerializeField] private float masterStandRadius;
    #endregion

    #region Properties

    public Transform Transform => transform;
    public StatSettings StatSettings => _statSettings;
    public MinionItem MinionItem => _minionItem;

    #endregion

    #region Private Fields

    private IMovementModule _movementModule;
    private IAttackController _attackController;
    private AnimationController _animationController;

    #endregion

    #region Unity Methods
    
    private Vector3 lookPos;
    private Camera _camera;

    private void Start()
    {
        _movementModule = GetComponent<IMovementModule>();
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
        }
        else
        {
            speedMultiplierForDistance = Mathf.Pow(distanceDif.magnitude, 2);
            moveDir = new Vector3(distanceDif.x, distanceDif.z, 0).normalized;   
        }
        _movementModule.MoveDirection(moveDir, _statSettings.MovementSpeed * speedMultiplierForDistance);
    }

    #endregion
}
