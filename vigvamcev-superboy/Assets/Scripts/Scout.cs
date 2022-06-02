using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Entity
{

    private float speed = 0.5f;
    private Vector3 dir;
    private bool movingRight = true;
    public Transform groundDetector;


    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        //animator = GetComponent<Animator>();
        dir = transform.right;
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime));
        RaycastHit2D raycast = Physics2D.Raycast(groundDetector.position, Vector2.down, boxCollider2d.bounds.extents.y + 0.5f);

        if (raycast.collider == false)
        {
            if (movingRight)
            {
                
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            { 
                
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
          
        }
        
    }

    private bool IsOnGround()
    {
        RaycastHit2D raycast = Physics2D.Raycast(groundDetector.position, Vector2.down, boxCollider2d.bounds.extents.y + 0.5f);
        if (raycast.collider == false)
        {
            Debug.DrawRay(groundDetector.position, Vector2.down, Color.red);
            return false;
        }
        Debug.DrawRay(groundDetector.position, Vector2.down, Color.blue);
        return true;
    }
}
