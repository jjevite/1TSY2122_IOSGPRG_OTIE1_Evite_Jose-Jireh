using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    private void Start()
    {
        currentClip = 15;
        maxClip = 15;
        currentAmmo = 30;
        maxAmmo = 60;
}

    public override void reload()
    {
        if (isReloading == false)
        {
            if (currentClip != maxClip)
            {
                StartCoroutine(reloadSpeed());
            }
        }
    }

    IEnumerator reloadSpeed()
    {
        isReloading = true;
        yield return new WaitForSeconds(2);

        if(currentAmmo >= maxClip - currentClip)
        {
            currentAmmo -= maxClip - currentClip;
            currentClip = maxClip;
        }
        if(currentAmmo < maxClip - currentClip)
        {
            currentClip += currentAmmo;
            currentAmmo = 0;
        }

        isReloading = false;
    }
    public override void firingTypePlayer(GameObject bullet)
    {
        if(currentClip <= 0)
        {
            return;
        }
        else if(isReloading == true)
        {
            return;
        }
        else
        {
            GameObject theBullet = Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
            theBullet.GetComponent<Bullet>().bulletDamage = 10;
            currentClip -= 1;
            //theBullet.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

    }

    bool isReloadingAI = false;
    bool isShootingAI = false;
    IEnumerator iShoot;
    IEnumerator iReload;

    public override void firingTypeAI(GameObject bullet)
    {
        if(currentClip > 0 && isShootingAI == false)
        {
            iShoot = shootAI(bullet);
            StartCoroutine(iShoot);
        }
        if(currentClip <= 0 && isReloadingAI == false)
        {
            iReload = reloadAI();
            StartCoroutine(iReload);
        }
    }

    public override void stopFiringAI()
    {
        currentClip = 0;
    }

    IEnumerator reloadAI()
    {
        isReloadingAI = true;
        yield return new WaitForSeconds(4f);
        currentClip += 15;
        isReloadingAI = false;
    }

    IEnumerator shootAI(GameObject bullet)
    {
        isShootingAI = true;
        while (currentClip > 0)
        {
            GameObject theBullet = Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
            theBullet.GetComponent<Bullet>().bulletDamage = 10;
            currentClip -= 1;
            yield return new WaitForSeconds(2f);
        }
        isShootingAI = false;
    }

}
