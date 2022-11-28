using System;
using _Scripts.GameCore.Player;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.InventorySystem
{
    public class Orb : MonoBehaviour
    {
        private OrbService _orbService;

        private Tweener _moveTween;
        private Tween _jumpTween;
        private Tween _rotateTween;

        public bool IsCollecteable = false;
        private void Start()
        {
            _orbService = ServiceLocator.Instance.Get<OrbService>();
            _orbService.RegisterOrb(this);
        }

        public void Collect()
        {
            if(!IsCollecteable) return;
            Vector2 pos = PlayerManager.Instance.transform.position;
            _moveTween = TweenHelper.LinearMoveTo(transform, pos, OnCollected).OnUpdate((() =>
            {
                _moveTween.ChangeEndValue(PlayerManager.Instance.transform.position); 
            }));
        }
        
        private void OnCollected()
        {
            _jumpTween.Kill();
            _rotateTween.Kill();
            _orbService.UnregisterOrb(this);
            gameObject.SetActive(false);//TODO Pooling
        }

        #region OrbAnimation

        public void StartAnimation()
        {
            Vector3 targetFallPosition = (Random.insideUnitSphere) * 3;
            targetFallPosition.y = 0;
            var transform1 = transform;
            _jumpTween = TweenHelper.BouncyFall(transform1, transform1.position + targetFallPosition, 1.5f, 1f, IdleAnimation);
        }
        
        private void IdleAnimation()
        {
            //TweenHelper.MoveUpMoveDownSequence(transform, 1f, 1f, 0.5f, 0.2f);
            _rotateTween = TweenHelper.RotateAround(transform, 1f);
            IsCollecteable = true;
        }

        #endregion
    }
}
