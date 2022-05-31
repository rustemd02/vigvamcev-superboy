using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Enemy : Entity
{
    [SerializeField] private int hp = 1;
    private float timer = 5;
    private bool turnLeft = true;
    public TextMeshProUGUI timerText;

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
        TurnAround();
    }

    void TurnAround()
    {
        if (timer > 1)
        {
            timer -= Time.deltaTime;
        } else
        {
            if (turnLeft)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                turnLeft = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                turnLeft = true;
            }
            timer += 5; 
        }
        DisplayTime(timer);
    }

    void DisplayTime(float currentTimerValue)
    {
        float seconds = Mathf.FloorToInt(currentTimerValue % 60);
        timerText.text = string.Format("{0:0}", seconds);


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
