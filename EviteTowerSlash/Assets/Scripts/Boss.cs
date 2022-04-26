using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isInPlace = false;
    [SerializeField] GameObject arrowGameObject;
    [SerializeField] GameObject enemyGameObject;

    private int[] bossPattern = new int[2];
    private int[] arrowToDisplay = new int[2];

    //[SerializeField] ParticleSystem partSystem;
    // Start is called before the first frame update
    void Start()
    {
        // Warning Sign
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isInPlace == true)
        {
            isInPlace = false;
            StartCoroutine(mainTimer());
        }
    }


    IEnumerator arrowTimer()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject newArrow = (GameObject)Instantiate(arrowGameObject, transform.position, Quaternion.identity);
            newArrow.GetComponent<BossArrows>().arrowToRender = arrowToDisplay[i];
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpawnMinions()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject enemyObjectIns = (GameObject)Instantiate(enemyGameObject, transform.position + new Vector3(2.0f, 0, 0), Quaternion.identity);
            enemyObjectIns.GetComponent<Enemy>().arrowRenderer.SetActive(false);
            enemyObjectIns.GetComponent<Enemy>().theArrow = bossPattern[i];
            yield return new WaitForSeconds(1.25f);
        }
    }
    IEnumerator mainTimer()
    {
        
        yield return new WaitForSeconds(1);

        ArrowPicker();
        StartCoroutine(arrowTimer());
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnMinions());

        yield return new WaitForSeconds(3);

        ArrowPicker();
        StartCoroutine(arrowTimer());
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnMinions());

        yield return new WaitForSeconds(3);

        ArrowPicker();
        StartCoroutine(arrowTimer());
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnMinions());
        
        yield return new WaitForSeconds(4);
        //partSystem.Play();
        
        FindObjectOfType<SpawnerManager>().keepSpawning = true;
        FindObjectOfType<SpawnerManager>().startSpawn = true;
        FindObjectOfType<GameMgr>().keepCount = true;
        Destroy(gameObject);
    }

    public void ArrowPicker()
    {
        for (int i = 0; i < 2; i++)
        {
            int theArrowEnemy = Random.Range(0, 8);
            bossPattern[i] = theArrowEnemy;

            arrowToDisplay[i] = bossPattern[i];
            if (bossPattern[i] == 0)
            {
                bossPattern[i] = 0;
            }
            else if (bossPattern[i] == 1)
            {
                bossPattern[i] = 1;
            }
            else if (bossPattern[i] == 2)
            {
                bossPattern[i] = 2;
            }
            else if (bossPattern[i] == 3)
            {
                bossPattern[i] = 3;
            }
            else if (bossPattern[i] == 4)
            {
                bossPattern[i] = 2;
            }
            else if (bossPattern[i] == 5)
            {
                bossPattern[i] = 3;
            }
            else if (bossPattern[i] == 6)
            {
                bossPattern[i] = 0;
            }
            else if (bossPattern[i] == 7)
            {
                bossPattern[i] = 1;
            }
        }
    }
}
