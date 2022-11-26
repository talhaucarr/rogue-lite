using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public static class TweenHelper
{
    
    public static Tween BouncyFall(Transform target, Vector2 endPosition, float jumpAmount, float duration, Action onComplete = null)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.DOMoveY(target.position.y + jumpAmount, duration/2).SetEase(Ease.InCubic));
        sequence.Append(target.DOMoveY( endPosition.y, duration/2).SetEase(Ease.OutBounce));
        sequence.Insert(0,target.DOMoveX( endPosition.x, duration).SetEase(Ease.InOutCubic));
        if(onComplete != null) sequence.onComplete += () => onComplete();
        return sequence;
    }
    public static Tween BouncyMoveTo(Transform transform, Vector2 targetPos, Action onComplete = null, float duration = .4f)
    {
        Tween tween = transform.DOMove(targetPos, duration).SetEase(Ease.OutBounce);
        if (onComplete != null) tween.onComplete += () => onComplete();
        return tween;
    }

    public static Tween LinearMoveTo(Transform transform, Vector2 targetPos, Action onComplete = null, float duration = .5f)
    {
        Tween tween = transform.DOMove(targetPos, duration).SetEase(Ease.Linear);
        if (onComplete != null) tween.onComplete += () => onComplete();
        return tween;
    }

    public static Tween Jump(Transform transform, Action onComplete = null, float jumpPower = 30, float duration = .25f)
    {
        Tween tween = transform.DOJump(transform.position,jumpPower, 1, duration).SetEase(Ease.Linear);
        if (onComplete != null) tween.onComplete += () => onComplete();
        return tween;
    }

    public static Tween CurvingMoveTo(Transform transform, Vector2 targetPoint, Action onComplete = null, float duration = .5f, 
        float curveAmountMultiplier = .2f, Ease sidewaysEase = Ease.InOutCubic, Ease forwardEase = Ease.InOutCubic)
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetPoint);
        Vector2 moveDir = (targetPoint - (Vector2)transform.position).normalized;
        Vector2 moveDirNormal = new Vector2(-moveDir.y, moveDir.x);
        int curveTowards = transform.position.x - targetPoint.x > 0 ? 1 : -1;
        Sequence sequence = DOTween.Sequence();
        sequence.Join(transform.DOBlendableMoveBy(curveTowards * moveDirNormal * distanceToTarget * curveAmountMultiplier, duration / 2).SetEase(sidewaysEase));
        sequence.Append(transform.DOBlendableMoveBy(-curveTowards * moveDirNormal * distanceToTarget * curveAmountMultiplier, duration / 2).SetEase(sidewaysEase));
        sequence.Insert(0, transform.DOBlendableMoveBy(targetPoint - (Vector2)transform.position, duration).SetEase(forwardEase));
        if (onComplete != null) sequence.onComplete += () => onComplete();
        return sequence;
    }

    public static Tween PassingBy(Transform transform, Vector2 spawnPoint, Vector2 waitingPoint, Vector2 targetPoint, float moveDuration, float waitDuration, Action onComplete = null)
    {
        float distanceToTarget = Vector2.Distance(spawnPoint, waitingPoint);
        Vector2 moveDir = (targetPoint - (Vector2)transform.position).normalized;
        Vector2 moveDirNormal = new Vector2(-moveDir.y, moveDir.x);
        Sequence sequence = DOTween.Sequence();
        sequence.Join(transform.DOBlendableMoveBy(moveDirNormal * distanceToTarget * .2f, moveDuration / 4).SetEase(Ease.InOutQuad));
        sequence.Append(transform.DOBlendableMoveBy(-moveDirNormal * distanceToTarget * .2f, moveDuration / 4).SetEase(Ease.InOutQuad));
        sequence.Insert(0, transform.DOBlendableMoveBy(waitingPoint - spawnPoint, moveDuration/2).SetEase(Ease.InOutQuad));
        sequence.AppendInterval(waitDuration);

        distanceToTarget = Vector2.Distance(waitingPoint, targetPoint);
        sequence.Append(transform.DOBlendableMoveBy(-moveDirNormal * distanceToTarget * .2f, moveDuration / 4).SetEase(Ease.InOutQuad));
        sequence.Append(transform.DOBlendableMoveBy(moveDirNormal * distanceToTarget * .2f, moveDuration / 4).SetEase(Ease.InOutQuad));
        sequence.Insert(waitDuration+(moveDuration/2), transform.DOBlendableMoveBy(targetPoint - waitingPoint, moveDuration/2).SetEase(Ease.InOutQuad));
        if (onComplete != null) sequence.onComplete += () => onComplete();
        return sequence;
    }

        public static Tween Shake(Transform target, Action onComplete = null, float shakeAngle = 14, float duration = 0.1f)
    {
        int randomDirection = UnityEngine.Random.value < .5 ? 1 : -1;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(target.DOPunchRotation(new Vector3(0, 0, randomDirection * shakeAngle), duration/2));
        sequence.Append(target.DOPunchRotation(new Vector3(0, 0, -randomDirection * (shakeAngle/2f)), duration/2));
        if (onComplete != null) sequence.onComplete += () => onComplete();
        return sequence;
    }

    public static Tween PunchScale(Transform target, Action onComplete = null, float scaleMultiplier = .3f, float duration = .2f)
    {
        Tween tween = target.DOPunchScale(target.localScale * scaleMultiplier, duration);
        if(onComplete != null) tween.onComplete += () => onComplete();
        return tween;
    }

    public static Tween ShrinkDisappear(Transform target, Action onComplete, float duration = .3f)
    {
        Tween tween = target.DOScale(Vector3.zero, duration).SetEase(Ease.InBack);
        if (onComplete != null) tween.onComplete += () => onComplete();
        return tween;
    }

    public static Tween Spin(Transform target, Action onComplete, float duration = .3f, bool infinite = false)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.DOBlendableRotateBy(new Vector3(0,0,-180), duration, RotateMode.FastBeyond360).SetEase(Ease.InOutCubic));
        sequence.Insert(0, target.DOBlendableRotateBy(new Vector3(0, 0, -180), duration, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        if (infinite) sequence.SetLoops(-1);
        if (onComplete != null) sequence.onComplete += () => onComplete();
        return sequence;
    }
    
    public static Tween FadeOutSprite(SpriteRenderer sprite, float duration, Action onComplete = null)
    {
        var tween = sprite.DOFade(0,duration).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
        return tween;
    }
    
    public static Tween PunchScale(Transform target, float duration, Action onComplete = null)
    {
        var tween = target.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), duration, 1, 1).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
        return tween;
    }
    
    public static Tween Path(Transform target, Vector2[] path, float moveSpeed, Action onComplete = null, Action<int> onWaypointChange = null)
    {
        Vector3[] pathArray3D = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            pathArray3D[i] = path[i];
        }

        Tween pathTween = target.DOPath(pathArray3D, moveSpeed,PathType.Linear, PathMode.Sidescroller2D);
        pathTween.SetEase(Ease.Linear);
        if(onWaypointChange != null) pathTween.OnWaypointChange(onWaypointChange.Invoke);
        pathTween.SetSpeedBased();
        if(onComplete != null) pathTween.OnComplete(() => onComplete());
        return pathTween;
    }

    
    public static Tween Arrow(Transform target, Vector2 endPosition, float speed, float arrowHeight, Action onComplete = null)
    {
        var position = target.position;
        Vector2 arrowHighPoint = new Vector2((position.x + endPosition.x) / 2, Mathf.Max(position.y, endPosition.y) + arrowHeight);
        
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.DOMoveY(arrowHighPoint.y, speed / 2).SetEase(Ease.OutQuad));
        sequence.Append(target.DOMoveY(endPosition.y, speed / 2).SetEase(Ease.InQuad));
        sequence.Insert(0, target.DOBlendableMoveBy(new Vector2(endPosition.x - position.x, 0), speed).SetEase(Ease.InOutQuad));
        if(onComplete != null) sequence.OnComplete(() => onComplete());
        return sequence;
    }
    
    public static Tween MoveUpMoveDownSequence(Transform target, float moveUpDuration, float moveDownDuration, float moveUpDistance, float moveDownDistance, Action onComplete = null)
    {
        var yAxis = target.position.y;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(target.DOMoveY(yAxis + moveUpDistance, moveUpDuration).SetEase(Ease.InQuad));
        sequence.Append(target.DOMoveY(yAxis - moveDownDistance, moveDownDuration).SetEase(Ease.InQuad));
        sequence.SetLoops(-1);
        if(onComplete != null) sequence.OnComplete(() => onComplete());
        return sequence;
    }
    
    
}
