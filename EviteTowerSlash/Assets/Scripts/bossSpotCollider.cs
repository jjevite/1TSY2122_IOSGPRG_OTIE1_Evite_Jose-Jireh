using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpotCollider : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
         
            collision.gameObject.transform.parent = this.gameObject.transform;
            collision.gameObject.GetComponent<Boss>().isInPlace = true;
        }
    }
    

}
