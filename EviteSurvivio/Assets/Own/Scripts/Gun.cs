using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunType gunType;
    public GameObject nozzle;

    public float spread;

    public bool isReloading = false;

    public int currentClip;
    public int maxClip;
    public int currentAmmo;
    public int maxAmmo;

    // Try to add cooldown inbetweeb fire
    // protected bool firingCD; 

    //public virtual void Init(GunType mGunType, int mAmmoCount)
    //{
    //    gunType = mGunType;
        
    //}

    public virtual void firingTypePlayer(GameObject bullet)
    {
        //Debug.Log("Firing from Gun Base Class");
    }

    public virtual void stopFire(GameObject bullet)
    {
        //Debug.Log("Stopping from Gun Base Class");
    }

    public virtual void firingTypeAI(GameObject bullet)
    {
        //Debug.Log("Firing from Gun Base Class");
    }

    public virtual void stopFiringAI()
    {

    }

    public virtual void reload()
    {
        //Debug.Log("Reloading from Gun Base Class");
    }
}
