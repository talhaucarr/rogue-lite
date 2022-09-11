using System.Collections;
using System.Collections.Generic;
using _Scripts.AttackSystem;
using _Scripts.HealthSystem;
using _Scripts.MovementSystem;
using _Scripts.Player;
using _Scripts.StatSystem;
using UnityEngine;

public class MinionController : MonoBehaviour
{

    #region Serialized Fields

    [SerializeField] private PlayerController minionMaster;
    [SerializeField] private StatSettings _statSettings;

    #endregion

    #region Properties

    public StatSettings StatSettings => _statSettings;

    #endregion

    #region Private Fields

    private IMovementModule _movementModule;
    private AttackController _attackController;
    private AnimationController _animationController;

    #endregion

    #region Unity Methods
    
    private Vector3 lookPos;
    private Camera _camera;

    private void Start()
    {
        _movementModule = GetComponent<IMovementModule>();
        _attackController = GetComponent<AttackController>();
        _animationController = GetComponent<AnimationController>();
        
        _movementModule.Setup(_animationController);
        _attackController.Setup(_statSettings);

        _camera = CameraManager.Instance.Camera;
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
        float speedMultiplierForDistance = Mathf.Pow(distanceDif.magnitude, 2);
        Vector3 moveDir = new Vector3(distanceDif.x, distanceDif.z, 0).normalized;
        _movementModule.Move(moveDir, _statSettings.MovementSpeed * speedMultiplierForDistance);
    }

    #endregion
}
