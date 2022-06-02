using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationStates
{
    idle,
    run
}

public class Hero : Entity
{
    [SerializeField] private float speed = 5f;
    public float hp = 5; 
    [SerializeField] private float jumpForce = 10f;
    public Transform stomper;
    
    
    public static Hero Instance { get; set; }

    public AnimationStates State
    {
        get { return (AnimationStates)animator.GetInteger("stages"); }
        set { animator.SetInteger("State", (int)value); }

    }


    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    private void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        if (IsOnGround())
        {
            State = AnimationStates.idle;
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (IsOnGround() && Input.GetButton("Jump"))
        {
            Jump();
        }
        if (Input.GetButton("Fire3"))
        {
            Hit();
        }

        if (transform.position.y < -3)
        {
            Die();
        }
    }

    private void Run()
    {
        if (IsOnGround())
        {
            State = AnimationStates.run;
        }
        Vector3 vector3 = transform.right * Input.GetAxis("Horizontal");
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, position + vector3, speed * Time.deltaTime);
        spriteRenderer.flipX = vector3.x < 0.0f;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsOnGround()
    {
        var boxCollider = boxCollider2d.bounds;
        RaycastHit2D raycast = Physics2D.Raycast(boxCollider.center, Vector2.down, boxCollider.extents.y + .1f, platformLayer);
        
        return raycast.collider != null;
    }

    private void Hit()
    {
        
    }

    public override void Die()
    {
        GameOverScreen.Instance.isDead = true;

    }

    public override void GetDamage()
    {
        if (hp > 1)
        {
            hp--;
        }
        else
        {
            Die();
        }
    }
}


