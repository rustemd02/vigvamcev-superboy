using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Entity
{
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    private bool isOnGround = true;


    private void Start()
    {
        dir = transform.right;
    }

    private void Update()
    {
        Move();
        CheckGround();
    }

    private void Move()
    {
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);
        if (isOnGround)
        {
            dir *= -1f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
          
        }
        
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 5.0f);
        isOnGround = collider.Length > 1;
    }
}
