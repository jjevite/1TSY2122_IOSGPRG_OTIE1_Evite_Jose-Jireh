using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    private IEnumerator fireCourotine;

    private void Start()
    {
        currentClip = 30;
        maxClip = 30;
        currentAmmo = 60;
        maxAmmo = 90;
    }
    public override void reload()
    {
        if (isReloading == false)
        {
            if(currentClip != maxClip)
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
            fireCourotine = contFire(bullet);
            StartCoroutine(fireCourotine);

        }
    }

    public override void stopFire(GameObject bullet)
    {
        StopCoroutine(fireCourotine);
    }

    IEnumerator contFire(GameObject bullet)
    {
        while (currentClip > 0)
        {
            // Simulating spread by rotating the nozzle of the gun based on the spread variable of the gun
            // Creating random rotation based on the spread
            Vector3 randomizeRotationSpread = new Vector3(0, 0, 1) * Random.Range(-spread, spread);
            // Rotate the nozzle based on the randomized spread
            nozzle.transform.Rotate(randomizeRotationSpread);
            //  instantiate a bullet.
            GameObject theBullet = Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
            theBullet.GetComponent<Bullet>().bulletDamage = 15;
            currentClip -= 1;
            // Put back to the original rotation before rotating so that it doesnt endlessly rotate
            nozzle.transform.Rotate(-randomizeRotationSpread);
            // Use var to tweak the firing speed if I have time
            yield return new WaitForSeconds(0.25f);
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
        currentClip += 30;
        isReloadingAI = false;
    }

    IEnumerator shootAI(GameObject bullet)
    {
        isShootingAI = true;
        while (currentClip > 0)
        {
            Vector3 randomizeRotationSpread = new Vector3(0, 0, 1) * Random.Range(-spread, spread);

            nozzle.transform.Rotate(randomizeRotationSpread);

            GameObject theBullet = Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
            theBullet.GetComponent<Bullet>().bulletDamage = 15;
            currentClip -= 1;

            nozzle.transform.Rotate(-randomizeRotationSpread);
            yield return new WaitForSeconds(1f);
        }
        isShootingAI = false;
    }
}
