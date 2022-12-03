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

        private void Start()
        {
            _orbService = ServiceLocator.Instance.Get<OrbService>();
            _orbService.RegisterOrb(this);
        }

        private void Update()
        {
            if(Vector3.Distance(transform.position, PlayerManager.Instance.transform.position) < 1)
            {
                _moveTween?.Kill();
                OnCollected();
            }
        }

        private void Collect()
        {   
            Vector3 pos = PlayerManager.Instance.transform.position;
            transform.DOMove(pos, 0.1f).OnUpdate((() =>
            {
                pos = PlayerManager.Instance.transform.position;
                transform.DOMove(pos, 0.1f);
            }));
        }

        private void OnCollected()
        {
            _jumpTween?.Kill();
            _orbService.UnregisterOrb(this);
            gameObject.SetActive(false);//TODO Pooling
        }

        #region OrbAnimation

        public void StartAnimation()
        {
            Vector3 targetFallPosition = (Random.insideUnitSphere) * 3;
            targetFallPosition.y = 0;
            var transform1 = transform;
            _jumpTween = TweenHelper.BouncyFall(transform1, transform1.position + targetFallPosition, 1.5f, 1f, Collect);
        }
        
        private void IdleAnimation()
        {
            _rotateTween = TweenHelper.RotateAround(transform, 1f);
        }

        #endregion
    }
}
