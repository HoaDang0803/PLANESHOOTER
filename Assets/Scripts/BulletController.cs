using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speedBullet = 1f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x,speedBullet);
    }
    
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("enemy"))
         {
             Destroy(this.gameObject);
         }
     }
}

