using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerMgr : MonoBehaviour
{
    [SerializeField] BoxCollider2D spawnArea;

    [SerializeField] GameObject enemy;
    public List<GameObject> enemyInWorld = new List<GameObject>();

    public GameObject HUD;
    public GameObject gameOverScreen;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        for (int i = 0; i < enemyInWorld.Count; i++)
        {
            if (enemyInWorld[i] == null)
            {
                enemyInWorld.RemoveAt(i);
            }
        }
        if(enemyInWorld.Count <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            Bounds bounds = spawnArea.bounds;

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            GameObject newEnemy = Instantiate(enemy, new Vector3(x, y), this.transform.rotation);
            enemyInWorld.Add(newEnemy);
        }
    }
}
