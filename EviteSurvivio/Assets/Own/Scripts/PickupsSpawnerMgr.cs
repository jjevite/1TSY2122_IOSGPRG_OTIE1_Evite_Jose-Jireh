using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSpawnerMgr : MonoBehaviour
{
    [SerializeField] BoxCollider2D spawnArea;

    [SerializeField] GameObject[] itemsToSpawn;
    public List<GameObject> itemsInWorld = new List<GameObject>();



    private void Start()
    {
        SpawnItems();
    }

    private void Update()
    {
        for (int i = 0; i < itemsInWorld.Count; i++)
        {
            if(itemsInWorld[i] == null)
            {
                itemsInWorld.RemoveAt(i);
            }
        }
    }

    private void SpawnItems()
    {
        for (int i = 0; i < 15; i++)
        {
            Bounds bounds = spawnArea.bounds;

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            GameObject newItem = Instantiate(itemsToSpawn[Random.Range(0, 6)], new Vector3(x, y), this.transform.rotation);
            itemsInWorld.Add(newItem);
        }
    }
}
