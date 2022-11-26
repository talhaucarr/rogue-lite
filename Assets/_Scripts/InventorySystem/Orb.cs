using UnityEngine;

namespace _Scripts.InventorySystem
{
    public class Orb : MonoBehaviour
    {
        public void StartAnimation()
        {
            Vector3 targetFallPosition = (Random.insideUnitSphere) * 3;
            targetFallPosition.y = 0;
            TweenHelper.BouncyFall(transform, transform.position + targetFallPosition, 1.5f, 1f, IdleAnimation);
        }
        
        private void IdleAnimation()
        {
            TweenHelper.MoveUpMoveDownSequence(transform, 1f, 1f, 0.5f, 0.2f);
        }
    }
}
