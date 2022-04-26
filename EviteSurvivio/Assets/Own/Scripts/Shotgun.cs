using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{

    private void Start()
    {
        currentClip = 2;
        maxClip = 2;
        currentAmmo = 6;
        maxAmmo = 12;
    }
    public override void reload()
    {
        if(isReloading == false)
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

        if (currentAmmo >= maxClip - currentClip)
        {
            currentAmmo -= maxClip - currentClip;
            currentClip = maxClip;
        }
        if (currentAmmo < maxClip - currentClip)
        {
            currentClip += currentAmmo;
            currentAmmo = 0;
        }

        isReloading = false;
    }
    public override void firingTypePlayer(GameObject bullet)
    {
        if (currentClip <= 0)
        {
            return;
        }
        else if (isReloading == true)
        {
            return;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                base.firingTypePlayer(bullet);
                Vector3 randomizeRotationSpread = new Vector3(0, 0, 1) * Random.Range(-spread, spread);
                Vector3 randomizedTranslateSpread = new Vector3(0, 1, 0) * Random.Range(-0.5f, 0.5f);

                nozzle.transform.Translate(randomizedTranslateSpread, Space.Self);
                nozzle.transform.Rotate(randomizeRotationSpread);

                GameObject theBullet = Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
                theBullet.GetComponent<Bullet>().bulletDamage = 20;

                nozzle.transform.Rotate(-randomizeRotationSpread);
                nozzle.transform.Translate(-randomizedTranslateSpread);
            }
            currentClip -= 1;
        }
     
    }

    bool isReloadingAI = false;
    bool isShootingAI = false;
    IEnumerator iShoot;
    IEnumerator iReload;

    public override void firingTypeAI(GameObject bullet)
    {
        if (currentClip > 0 && isShootingAI == false)
        {
            iShoot = shootAI(bullet);
            StartCoroutine(iShoot);
        }
        if (currentClip <= 0 && isReloadingAI == false)
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
        currentClip += 2;
        isReloadingAI = false;
    }

    IEnumerator shootAI(GameObject bullet)
    {
        isShootingAI = true;
        while (currentClip > 0)
        {
            for (int i = 0; i < 8; i++)
            {
                base.firingTypePlayer(bullet);
                Vector3 randomizeRotationSpread = new Vector3(0, 0, 1) * Random.Range(-spread, spread);
                Vector3 randomizedTranslateSpread = new Vector3(0, 1, 0) * Random.Range(-0.5f, 0.5f);

                nozzle.transform.Translate(randomizedTranslateSpread, Space.Self);
                nozzle.transform.Rotate(randomizeRotationSpread);

                GameObject theBullet = Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
                theBullet.GetComponent<Bullet>().bulletDamage = 20;

                nozzle.transform.Rotate(-randomizeRotationSpread);
                nozzle.transform.Translate(-randomizedTranslateSpread);

            }
            currentClip -= 1;
            yield return new WaitForSeconds(2f);
        }
        isShootingAI = false;
    }

}
