using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Entity : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rigidbody;
    public LayerMask platformLayer;
    public BoxCollider2D boxCollider2d;
    public SpriteRenderer spriteRenderer;
    public Animator animator;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void GetDamage()
    {

    }

    public virtual void Die() 
    {
        Destroy(this.gameObject);
    }
}
