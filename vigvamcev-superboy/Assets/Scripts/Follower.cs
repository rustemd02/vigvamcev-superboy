using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Entity
{
    public Transform player;
    public Transform groundDetector;
    private float speed = 3f;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = player.position - transform.position;
        float distance = Vector2.Distance(transform.position, player.position);
        if (IsOnGround() && distance < 2)
        {
            if (direction.x < 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                rigidbody.velocity = new Vector2(-speed, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidbody.velocity = new Vector2(speed, 0);
            }

        }
        else
        {
            rigidbody.velocity = new Vector2(0, 0);
        }

        //rigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));

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
