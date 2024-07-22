using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Enemy
{
    [SerializeField] private int damage;
    private Rigidbody2D _rigidbody2D;

    public override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.down * speed * Time.fixedDeltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            Dead();
            LevelManager.ChangeHp(-damage);
        }
    }
}
