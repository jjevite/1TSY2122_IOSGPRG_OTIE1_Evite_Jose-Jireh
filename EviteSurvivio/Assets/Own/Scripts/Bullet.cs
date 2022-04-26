using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;
    public int bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + new Vector2(1, 0) * bulletSpeed * Time.deltaTime);
        transform.Translate(new Vector2(1, 0) * bulletSpeed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Unit"))
        {
            collision.gameObject.GetComponent<Player>().playerhealth -= bulletDamage;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health -= bulletDamage;
        }
        Destroy(gameObject);
    }
}
