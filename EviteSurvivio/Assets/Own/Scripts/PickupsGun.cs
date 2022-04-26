using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsGun : Pickups
{
    // public GameObject[] guns;
    public GunType gunType;

    public HUD hud;

    public Player player;

    private void Start()
    {
        GameObject hudObj = GameObject.Find("HUD");
        hud = hudObj.GetComponent<HUD>();
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            if (other.GetComponent<Unit>().hasPrimary == false && (gunType == GunType.RifleGunType || gunType == GunType.ShotgunGunType))
            {
                GameObject newGun = Instantiate(guns[(int)gunType], other.GetComponent<Unit>().handle.transform.position, Quaternion.identity, other.transform);
                other.GetComponent<Unit>().hasPrimary = true;
                other.GetComponent<Unit>().primaryGun = newGun;
                newGun.transform.localEulerAngles = new Vector3(0, 0, 0);
                hud.gunCheck();
                player.swapToPrimary();
                base.OnTriggerEnter2D(other);
            }

            if (other.GetComponent<Unit>().hasSecondary == false && gunType == GunType.PistolGunType)
            {
                GameObject newGun = Instantiate(guns[(int)gunType], other.GetComponent<Unit>().handle.transform.position, Quaternion.identity, other.transform);
                other.GetComponent<Unit>().hasSecondary = true;
                other.GetComponent<Unit>().secondaryGun = newGun;
                newGun.transform.localEulerAngles = new Vector3(0, 0, 0);
                hud.gunCheck();
                player.swapToSecondary();
                base.OnTriggerEnter2D(other);
            }
        }
        if (other.CompareTag("Enemy"))
        {
            base.OnTriggerEnter2D(other);
        }

    }
}
