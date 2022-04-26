using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyList = new List<Enemy>();
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject extraLyf;
    [SerializeField] GameObject Boss;
    [SerializeField] public bool keepSpawning = true;
    [SerializeField] public bool startSpawn = true;

    private void Start()
    {

    }

    private void Update()
    {
        if(startSpawn == true)
        {
            startSpawn = false;
            spawnNormal();
        }
       
    }

    void spawnNormal()
    {
        StartCoroutine(SpawnTimer());
    }

    public void SpawnBoss()
    {
        GameObject newEnemy = (GameObject)Instantiate(Boss, transform.position -new Vector3(1.0f, 0, 0), Quaternion.identity);
    }


    void SpawnEnemy()
    {
        GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().ArrowPicker();
        newEnemy.GetComponent<Enemy>().renderArrow();


        AddEnemyToList(newEnemy.GetComponent<Enemy>());
    }

    void SpawnExtraLyf()
    {
        if(randomBool() == true)
        {
            Instantiate(extraLyf, transform.position - new Vector3(0, 9, 0), Quaternion.identity);
        }
        
    }

    void AddEnemyToList(Enemy enemyToAdd)
    {
        enemyList.Add(enemyToAdd);
    }

    public void removeEnemyToList(GameObject enemyToRemove)
    {
        enemyList.Remove(enemyToRemove.GetComponent<Enemy>());
    }

    IEnumerator SpawnTimer()
    {
        while(keepSpawning == true)
        {
            SpawnEnemy();
            SpawnExtraLyf();
            yield return new WaitForSeconds(Random.Range(1.5f, 2.0f));
        }
        
    }

    bool randomBool()
    {
        if (Random.value >= 0.75)
        {

            return true;
        }
        return false;
    }
}
