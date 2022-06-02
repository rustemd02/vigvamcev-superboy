using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float bounceForce = 10f;
    
    void Start()
    {
        _rigidbody2D = transform.parent.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Head"))
        {
            other.gameObject.GetComponent<HeadCollider>().enemy.Die();
            _rigidbody2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
