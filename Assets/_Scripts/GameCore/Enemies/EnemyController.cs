using System.Collections;
using System.Collections.Generic;
using _Scripts.GameCore.Player;
using _Scripts.HealthSystem;
using _Scripts.MovementSystem;
using _Scripts.StatSystem;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEntityController
{

    #region Serialized Fields
    
    [SerializeField] private StatSettings _statSettings;
    #endregion

    #region Properties

    public Transform Transform => transform;
    public StatSettings StatSettings => _statSettings;

    #endregion

    #region Private Fields

    private IMovementModule _movementModule;
    private IAttackController _attackController;
    private HealthController _healthController;
    private AnimationController _animationController;

    #endregion

    #region Unity Methods
    
    private Vector3 lookPos;
    private Camera _camera;

    private void Start()
    {
        EnemyManager.Instance.RegisterEnemy(this);
        _movementModule = GetComponent<IMovementModule>();
        _attackController = GetComponent<IAttackController>();
        _animationController = GetComponent<AnimationController>();
        _healthController = GetComponent<HealthController>();
        
        _healthController.Setup(_statSettings.Health);
        _healthController.onDeath.AddListener(OnDeath);
        _movementModule.Setup(_animationController);
        _attackController.Setup(_statSettings);

        _camera = CameraManager.Instance.Camera;
    }

    private void Update()
    {
        MoveToPlayer();
        LookAtPlayer();
    }
    
    #endregion
    
    #region Public Methods
    
    

    #endregion

    #region Private Methods

    private void OnDeath()
    {
        EnemyManager.Instance.UnRegisterEnemy(this);
    }
    
    private void LookAtPlayer()
    {
        transform.LookAt(PlayerManager.Instance.transform, Vector3.up);
    }

    private void MoveToPlayer()
    {
        Vector3 distanceDif = PlayerManager.Instance.transform.position - transform.position;
        Vector3 moveDir = new Vector3(distanceDif.x, distanceDif.z, 0).normalized;
        _movementModule.MoveDirection(transform, moveDir, _statSettings.MovementSpeed);
    }

    #endregion
}
