using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] BoxCollider2D patrolArea;
    private float angleOfRotation;


    [SerializeField] GameObject[] weaponPool;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform handle;
    private Gun gun;

    public int health = 100;

    private void Awake()
    {
        GameObject area = GameObject.FindGameObjectWithTag("PatrolArea");
        patrolArea = area.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        GameObject gunObj = Instantiate(weaponPool[Random.Range(0, weaponPool.Length)], handle.position, handle.transform.rotation, this.transform);
        gun = gunObj.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            Destroy(gameObject);
        }
        //agent.SetDestination(target.position);
    }

    public void setNewDestination()
    {
        Bounds bounds = patrolArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        agent.SetDestination(new Vector3(x, y));

        angleOfRotation = Mathf.Atan2(y, x) * 180f / Mathf.PI;
    }

    public void lookAtDestination()
    {
        transform.localEulerAngles = new Vector3(0, 0, angleOfRotation);
    }

    public bool checkIfNear()
    {
        if (agent.remainingDistance < 2)
            return true;
        return false;
    }

    public void clearPath()
    {
        agent.ResetPath();
    }

    public void shoot()
    {
        gun.GetComponent<Gun>().firingTypeAI(bullet);
    }

    public void stopShoot()
    {
        gun.GetComponent<Gun>().stopFiringAI();
    }
}
