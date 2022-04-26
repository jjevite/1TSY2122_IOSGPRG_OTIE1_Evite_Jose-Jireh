using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(lifeTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Player>().isDashing == true)
        {
            collision.gameObject.GetComponent<Player>().life += 1;
            Destroy(gameObject);
            FindObjectOfType<GameMgr>().previewLyf();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            

        }
    }
   
    IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
