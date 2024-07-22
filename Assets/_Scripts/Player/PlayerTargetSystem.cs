using System;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerTargetSystem : MonoBehaviour
{
    [CanBeNull] public static ITarget ActiveTarget;
    
    private CapsuleCollider2D _collider;
    private void Start()
    {
        ActiveTarget = null;
        _collider = GetComponent<CapsuleCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ITarget target))
        {
            if(target.TargetIgnore) return;
            ActiveTarget = target;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ITarget target))
        {
            if (target == ActiveTarget) ActiveTarget = null;
        }
    }

    private void FixedUpdate()
    {
        if(ActiveTarget == null) FindNewTarget();
    }

    private void FindNewTarget()
    {
        Collider2D[] results = Physics2D.OverlapCapsuleAll(transform.position, _collider.size, _collider.direction, 360f);
        foreach (Collider2D collider in results)
        {
            if (collider.gameObject.TryGetComponent(out ITarget target))
            {
                if(target.TargetIgnore) return;
                ActiveTarget = target;
            }
        }
    }
}
