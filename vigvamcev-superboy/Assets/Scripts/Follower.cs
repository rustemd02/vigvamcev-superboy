using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Entity
{
    public Transform player;
    private float distance;
    private float timeBetweenShots = 2;
    public GameObject bullet;
    public Transform groundDetector;
    private float walkSpeed = 3f;
    private float shootSpeed = 400f;
    private Vector3 direction;
    private bool canShoot;
    

    void Start()
    {
        canShoot = true;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (IsOnGround() && distance < 5)
        {
            if (canShoot)
            StartCoroutine(Shoot());

            Move();
        } else
        {
            StopMoving();
        }

        
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        GameObject newBullet = Instantiate(bullet, groundDetector.position, Quaternion.identity);
        if (direction.x < 0)
        {
            shootSpeed = -Math.Abs(shootSpeed);
            transform.eulerAngles = new Vector3(0, -180, 0);
        } else
        {
            shootSpeed = Math.Abs(shootSpeed);
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Time.fixedDeltaTime, 0);
        canShoot = true;
    }

    void Move()
    {
        direction = player.position - transform.position;
        if (direction.x < 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                    rigidbody.velocity = new Vector2(-walkSpeed, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rigidbody.velocity = new Vector2(walkSpeed, 0);
            }


    }

    void StopMoving()
    {
        rigidbody.velocity = new Vector2(0, 0);
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
