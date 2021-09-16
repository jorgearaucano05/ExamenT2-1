using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ZombieMujerController : MonoBehaviour
{
    public float velocityX = 10;
    public float jumpforce = 50;
    
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (collision.gameObject.tag=="Pared2")
        {
            Debug.Log("Collision: "+collision.gameObject.name);
            velocityX=-10;
            sp.flipX = true;
            
        }
        
        if (collision.gameObject.tag=="Pared1")
        {
            Debug.Log("Collision: "+collision.gameObject.name);
            velocityX=10;
            sp.flipX = false;
            
        }
        
        if (collision.gameObject.name == "Suelo")
        {
            Debug.Log("Collision: "+collision.gameObject.name);
            rb.AddForce(Vector2.up*jumpforce,ForceMode2D.Impulse);
        }
    }
    
}
