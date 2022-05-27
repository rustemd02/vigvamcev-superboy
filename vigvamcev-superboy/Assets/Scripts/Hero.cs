using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private float speed = 3f;
    [SerializeField] private int hp = 5;
    [SerializeField] private float jumpForce = 1f;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderer;
   

    public static Hero Instance { get; set; }
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    private void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isOnGround() && Input.GetButton("Jump"))
        {
            Jump();
        }
        if (Input.GetButton("Fire3"))
        {
            Fire();
        }
    }

    private void Run()
    {
        Vector3 vector3 = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + vector3, speed * Time.deltaTime);
        spriteRenderer.flipX = vector3.x < 0.0f;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool isOnGround()
    {
        RaycastHit2D raycast = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + .1f, platformLayer);
        
        return raycast.collider != null;
    }

    private void Fire()
    {

    }

    public override void GetDamage()
    {
        hp -= 1;
        Debug.Log(hp);
    }
}


