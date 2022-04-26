using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingSword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            FindObjectOfType<GameMgr>().scoreCount += 20;
            FindObjectOfType<SpawnerManager>().removeEnemyToList(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
