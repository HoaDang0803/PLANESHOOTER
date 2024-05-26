using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1f;

    private float dirX = 0f;

    public GameObject bullet;
    public Transform firePos;
    public float fireRate=0.1f;

   
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Shoot(fireRate);
    }
    
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed,rb.velocity.y);
    }

    private void Shoot(float fireRate)
    {
        StartCoroutine(IEShoot(fireRate));
    }

    private IEnumerator IEShoot(float fireRate)
    {
        while(true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(fireRate);
        }
    }
    
    void SpawnBullet()
    {
        GameObject newbullet = Instantiate(bullet,firePos.position,firePos.rotation);
      
    }
}
