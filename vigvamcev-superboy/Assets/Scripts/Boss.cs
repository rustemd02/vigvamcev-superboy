using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Boss : Entity
{
    public int hp = 1;
    private float timer = 5;
    public GameObject sniperBullet;
    public Transform bulletSpawner, groundDetector, placeholder;
    private float shootSpeed = 600f;
    [SerializeField] private Transform player;
    public TextMeshProUGUI timerText;
    private bool isChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        placeholder = bulletSpawner;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer();
        
       ChangeBulletSource();
    }

    void ChangeBulletSource()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < 10)
        {
            if (!isChanged)
            {
                placeholder = groundDetector;
                isChanged = true;
            }
        }
        else
        {
            placeholder = bulletSpawner;
            isChanged = false;
        }
        
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
        
        GameObject newBullet = Instantiate(sniperBullet, placeholder.position, Quaternion.identity);
        newBullet.transform.localScale += new Vector3(1, 1, 1);
        newBullet.transform.eulerAngles = new Vector3(0, -180, 0);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime, 0);
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
