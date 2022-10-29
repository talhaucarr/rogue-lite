using UnityEngine;

namespace _Scripts.AnimationSystem
{
    public class AnimationController : MonoBehaviour
    {
        private const string WALKING_KEY = "walking";
        private const string WALKING_SPEED_KEY = "walkingSpeed";
        private const string IDLE_SPEED_KEY = "idleSpeed";
        
        private static readonly int Walking = Animator.StringToHash(WALKING_KEY);
        private static readonly int WalkingSpeed = Animator.StringToHash(WALKING_SPEED_KEY);
        private static readonly int IdleSpeed = Animator.StringToHash(IDLE_SPEED_KEY);
    
        [BHeader("Animator")]
        [SerializeField] private Animator animator;
        
        [BHeader("Settings")] 
        [SerializeField] private float movementSpeedMultiplier;
        [SerializeField] private float idleSpeedMultiplier;

        private void Awake()
        {
            animator.SetFloat(IdleSpeed, idleSpeedMultiplier);
        }

        public void SetWalking(bool isWalking, float moveSpeed, Vector3 direction = default)
        {
            animator.SetBool(Walking, isWalking);
            animator.SetFloat(WalkingSpeed, movementSpeedMultiplier * moveSpeed);
        }
    }
}
