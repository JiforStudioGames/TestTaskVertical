using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public abstract class Enemy : Target
{
    [Header("Base Settings (you can override)")]
    public bool randomHp;
    [HideIf(nameof(randomHp))] public int hp;
    [ShowIf(nameof(randomHp))] [SerializeField] private int _hpRandomMin;
    [ShowIf(nameof(randomHp))] [SerializeField] private int _hpRandomMax;
    
    public bool randomSpeed;
    [HideIf(nameof(randomSpeed))] public float speed;
    [ShowIf(nameof(randomSpeed))] [SerializeField] private float _speedRandomMin;
    [ShowIf(nameof(randomSpeed))] [SerializeField] private float _speedRandomMax;

    [Space] public EnemyType enemyType;
    
    [Space]
    [SerializeField] protected ParticleSystem onDamageEffect;
    [SerializeField] protected ParticleSystem onDestroyEffect;

    public int currentHp { get; protected set; }

    public Action<int> onHpChange;
    public Action onDead;
    
    public virtual void Awake()
    {
        if (randomHp) hp = Random.Range(_hpRandomMin, _hpRandomMax);
        if (randomSpeed) speed = Random.Range(_speedRandomMin, _speedRandomMax);
        currentHp = hp;
    }

    public override void TakeDamage()
    {
        currentHp--;
        onHpChange?.Invoke(currentHp);
        onDamageEffect.Play();

        if (currentHp == 0)
        {
            Dead();
        }
    }
    
    public EnemyType GetEnemyType()
    {
        return enemyType;
    }

    public virtual void Dead()
    {
        onDestroyEffect.transform.SetParent(transform.parent);
        onDestroyEffect.Play();
        onDead?.Invoke();
        Destroy(gameObject);
    }
}
