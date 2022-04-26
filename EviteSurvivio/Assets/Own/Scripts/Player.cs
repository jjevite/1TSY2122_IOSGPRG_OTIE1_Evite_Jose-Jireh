using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Unit
{
    public GameObject bullet;
    public bool onPrimaryWep;
    public int playerhealth;

    public GameObject gameOverLose;
    private void Awake()
    {
        playerhealth = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(playerhealth <= 0 )
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            hasPrimary = false;
            Destroy(primaryGun);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            hasSecondary = false;
            Destroy(secondaryGun);
        }
    }

    public void OnMouseDowner()
    {
        if(onPrimaryWep == true && hasPrimary == true)
        {
            primaryGun.GetComponent<Gun>().firingTypePlayer(bullet);
        }
        else if(onPrimaryWep == false && hasSecondary == true)
        {
            secondaryGun.GetComponent<Gun>().firingTypePlayer(bullet);
        }    

    }

    public void onMouseUpper()
    {
        if (onPrimaryWep == true && hasPrimary == true)
        {
            primaryGun.GetComponent<Gun>().stopFire(bullet);
        }
        else if (onPrimaryWep == false && hasSecondary == true)
        {
            secondaryGun.GetComponent<Gun>().stopFire(bullet);
        }
    }

    public void reloadPlayer()
    {
        if (onPrimaryWep == true && hasPrimary == true)
        {
            primaryGun.GetComponent<Gun>().reload();
        }
        else if (onPrimaryWep == false && hasSecondary == true)
        {
            secondaryGun.GetComponent<Gun>().reload();
        }
    }

    public void swapToPrimary()
    {
        onPrimaryWep = true;
        if(primaryGun != null)
        {
            primaryGun.GetComponent<SpriteRenderer>().enabled = true;
            //primaryGun.SetActive(true);
        }
        if (secondaryGun != null)
        {
            secondaryGun.GetComponent<SpriteRenderer>().enabled = false;
            //secondaryGun.SetActive(false);
        }
    }

    public void swapToSecondary()
    {
        onPrimaryWep = false;
        if(primaryGun != null)
        {
            primaryGun.GetComponent<SpriteRenderer>().enabled = false;
            //primaryGun.SetActive(false);
        }
        if(secondaryGun != null)
        {
            secondaryGun.GetComponent<SpriteRenderer>().enabled = true;
            //secondaryGun.SetActive(true);
        }            

    }
}
