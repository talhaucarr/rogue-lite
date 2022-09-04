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
    
    public static void FadeOutSprite(SpriteRenderer sprite, float duration, Action onComplete = null)
    {
        sprite.DOFade(0, duration).OnComplete(() =>
        {
            if (onComplete != null) onComplete();
        });
    }
    
    public static void PunchScale(Transform target, float duration, Action onComplete = null)
    {
        target.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), duration, 1, 1).OnComplete(() =>
        {
            if (onComplete != null) onComplete();
        });
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
        Vector2 arrowHighPoint = new Vector2((target.position.x + endPosition.x) / 2, Mathf.Max(target.position.y, endPosition.y) + arrowHeight);
        
        Sequence sequence = DOTween.Sequence();
        sequence.Join(target.DOMoveY(arrowHighPoint.y, speed / 2).SetEase(Ease.OutQuad));
        sequence.Append(target.DOMoveY(endPosition.y, speed / 2).SetEase(Ease.InQuad));
        sequence.Insert(0, target.DOBlendableMoveBy(new Vector2(endPosition.x - target.position.x, 0), speed).SetEase(Ease.InOutQuad));
        if(onComplete != null) sequence.OnComplete(() => onComplete());
        return sequence;
    }
    
    
}
