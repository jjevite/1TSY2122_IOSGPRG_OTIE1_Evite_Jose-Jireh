using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool hasPrimary;
    public bool hasSecondary;

    public GameObject primaryGun;
    public GameObject secondaryGun;

    public GameObject handle;
    // Because getcomponent is bad 
    /*
    public Gun primaryGunS;
    public Gun secondaryGunS;

    public void assignGameObjectGunToS()
    {
        primaryGunS = primaryGun.GetComponent<Gun>();
        secondaryGunS = secondaryGun.GetComponent<Gun>();
    }
    */
}
