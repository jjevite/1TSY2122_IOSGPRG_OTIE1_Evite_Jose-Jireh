using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    PistolGunType,
    ShotgunGunType,
    RifleGunType
}

public enum AmmoType
{
    PistolAmmoType,
    ShotgunAmmoType,
    RifleAmmoType
}

public class PickupsAmmo : Pickups
{
    public AmmoType ammoType;
    public int ammoToAdd;
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            if (other.GetComponent<Unit>().hasPrimary == true)
            {
                if ((int)other.GetComponent<Unit>().primaryGun.GetComponent<Gun>().gunType == (int)ammoType)
                {
                    other.GetComponent<Unit>().primaryGun.GetComponent<Gun>().currentAmmo += ammoToAdd;
                    base.OnTriggerEnter2D(other);
                }
            }

            if (other.GetComponent<Unit>().hasSecondary == true)
            {
                if ((int)other.GetComponent<Unit>().secondaryGun.GetComponent<Gun>().gunType == (int)ammoType)
                {
                    other.GetComponent<Unit>().secondaryGun.GetComponent<Gun>().currentAmmo += ammoToAdd;
                    base.OnTriggerEnter2D(other);
                }
            }
        }
        if (other.CompareTag("Enemy"))
        {
            base.OnTriggerEnter2D(other);
        }
    }
}
