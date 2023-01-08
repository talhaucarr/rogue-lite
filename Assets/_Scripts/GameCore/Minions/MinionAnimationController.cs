using UnityEngine;

namespace _Scripts.GameCore.Minions
{
    public class MinionAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IsWalking = Animator.StringToHash("walking");
        private static readonly int Attack = Animator.StringToHash("attack");
        
        public void SetWalkingAnimation(bool isWalking)
        {
            _animator.SetBool(IsWalking, isWalking);
        }
        
        public void SetAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }
    }
}
