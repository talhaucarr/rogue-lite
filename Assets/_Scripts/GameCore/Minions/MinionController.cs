using _Scripts.GameCore.Player;
using _Scripts.ItemSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.Minions
{
    public abstract class MinionController : MonoBehaviour
    {

        #region Serialized Fields
    
        [BHeader("Master")]
        [SerializeField] private PlayerController minionMaster;

        [BHeader("Modules")]
        [SerializeField] private MinionMovementModule _movementModule;
    
        [BHeader("General")]
        [SerializeField] protected StatSettings _statSettings;
        [SerializeField] protected MinionItem _minionItem;

        [BHeader("VFX")]
        [SerializeField] private GameObject _trailVFX;
    
        #endregion

        #region Properties
        
        public StatSettings StatSettings => _statSettings;
        public MinionItem MinionItem => _minionItem;

        #endregion

        #region Private Fields
    
        private float masterStandRadius = 1.7f;

        #endregion

        #region Unity Methods
    
        private Vector3 lookPos;

        private void Start()
        {
            CreateAttackByType();
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
            var lookPos = minionMaster.transform.position - transform.position;
            lookPos.x = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 0.5f);
        }

        private void MoveToMaster()
        {
            Vector3 distanceDif = minionMaster.transform.position - transform.position;
            Vector3 moveDir;
            float speedMultiplierForDistance;
            if (distanceDif.magnitude < masterStandRadius)
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

            _movementModule.MoveDirection(moveDir, _statSettings.GetStat(StatKey.MoveSpeed)*speedMultiplierForDistance);
        }

        #endregion
    }
}
