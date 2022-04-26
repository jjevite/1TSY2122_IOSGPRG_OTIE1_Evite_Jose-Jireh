using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRange : MonoBehaviour
{
    public GameObject bg;
    public int arrowToKill;
    bool isEvaluating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrowToKill = gameObject.GetComponentInParent<Enemy>().theArrow;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bg.SetActive(true);

            if (gameObject.GetComponentInParent<Enemy>().isYellowArrow == true && gameObject.GetComponentInParent<Enemy>().inRange == false)
            {
                gameObject.GetComponentInParent<Enemy>().inRange = true;
                gameObject.GetComponentInParent<Enemy>().renderArrow();
            }
         

            if (collision.gameObject.GetComponent<Player>().Arrow == arrowToKill && isEvaluating == false)
            {
                FindObjectOfType<SpawnerManager>().removeEnemyToList(transform.parent.gameObject);
                Destroy(transform.parent.gameObject);
                FindObjectOfType<GameMgr>().addToMeter(10);
                FindObjectOfType<GameMgr>().scoreCount += 20;
            }
            else if (collision.gameObject.GetComponent<Player>().Arrow == 8 && isEvaluating == false)
            {
                // Do Nothing
            }
            else if(collision.gameObject.GetComponent<Player>().Arrow != arrowToKill && isEvaluating == false)
            {
                StartCoroutine(DamagePlayerInRange(collision));
            }
        }
    
    }

    IEnumerator DamagePlayerInRange(Collider2D collidingPlayer)
    {
        isEvaluating = true;
        collidingPlayer.gameObject.GetComponent<Player>().life -= 1;
        yield return new WaitForSeconds(0.25f);
        isEvaluating = false;
      
    }
}
