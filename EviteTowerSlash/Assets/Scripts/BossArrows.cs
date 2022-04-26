using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArrows : MonoBehaviour
{
    [SerializeField] public Sprite[] arrowSprites;
    public int arrowToRender = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = arrowSprites[arrowToRender];
        StartCoroutine(lifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
