using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Boss : Entity
{
    [SerializeField] private int hp = 1;
    private float timer = 5;
    public GameObject sniperBullet;
    public Transform groundDetector;
    private float shootSpeed = 2000f;
    public TextMeshProUGUI timerText;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (timer > 1)
        {
            timer -= Time.deltaTime;
        } else
        {
            Shoot();
            timer += 5; 
        }
        DisplayTime(timer);
    }

    void DisplayTime(float currentTimerValue)
    {
        float seconds = Mathf.FloorToInt(currentTimerValue % 60);
        timerText.text = string.Format("{0:0}", seconds);
        
    }
    
    void Shoot()
    {
        canShoot = false;
        
        GameObject newBullet = Instantiate(sniperBullet, groundDetector.position, Quaternion.identity);
        newBullet.transform.localScale += new Vector3(1, 1, 1);
        newBullet.transform.eulerAngles = new Vector3(0, -180, 0);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime, 0);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            hp--;
            Debug.Log("hp врага" + hp);
        }
        if (hp < 1)
        {
            Die();
        }
    }
}
