using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int hp = 5;
    [SerializeField] private float jumpForce = 1f;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private bool isOnGround = true;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isOnGround && Input.GetButton("Jump"))
        {
            Jump();
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

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isOnGround = collider.Length > 1;
    }
}
