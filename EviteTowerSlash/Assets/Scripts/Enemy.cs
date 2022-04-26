using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Sprite[] arrowSprites;
    [SerializeField] public Sprite[] yellowArrowSprites;
    [SerializeField] public GameObject arrowRenderer;

    // Replacing int with enum
    //[SerializeField] public Direction enemyArrow;

    [SerializeField] public bool isYellowArrow = false;
    [SerializeField] public int theArrow;
    private int arrowToDisplay;

    
    public bool inRange = false;


    // Start is called before the first frame update
    void Start()
    {
        if(isYellowArrow == true)
        {
            StartCoroutine(yellowArrowTimer());
        }
    }

    public void renderArrow()
    {
        arrowRenderer.GetComponent<SpriteRenderer>().sprite = arrowSprites[arrowToDisplay];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator yellowArrowTimer()
    {
        while(!inRange)
        {
            arrowRenderer.GetComponent<SpriteRenderer>().sprite = yellowArrowSprites[Random.Range(0, yellowArrowSprites.Length)];
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Player>().isMegaDashing == false)
        {
            StartCoroutine(DamagePlayer(collision));
        }
        else
        {
            FindObjectOfType<GameMgr>().scoreCount += 10;
            FindObjectOfType<SpawnerManager>().removeEnemyToList(this.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator DamagePlayer(Collision2D collidingPlayer)
    {
        while(true)
        {
            collidingPlayer.gameObject.GetComponent<Player>().life -= 1;
            yield return new WaitForSeconds(0.25f);
        }
    }
    public void ArrowPicker()
    {
        theArrow = Random.Range(0, 16);
        if(Random.value >= 0.9)
        {
            theArrow = Random.Range(0, 4);
            isYellowArrow = true;
        }
        arrowToDisplay = theArrow;
        if(theArrow == 8)
        {
            theArrow = 2;
        }
        else if(theArrow == 9)
        {
            theArrow = 3;
        }
        else if(theArrow == 10)
        {
            theArrow = 0;
        }
        else if(theArrow == 11)
        {
            theArrow = 1;
        }
        else if (theArrow == 12)
        {
            theArrow = 6;
        }
        else if (theArrow == 13)
        {
            theArrow = 7;
        }
        else if (theArrow == 14)
        {
            theArrow = 4;
        }
        else if (theArrow == 15)
        {
            theArrow = 5;
        }
    }
   
}
