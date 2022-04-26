using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    // Progress Bar Var
    private int minimum;
    public int maximum;
    public int current;
    public Image Mask;

    public Button but;

    public Player player;

    public Sprite[] gunImages;
    public Image primaryButton;
    public Image secondaryButton;


    public TextMeshProUGUI clipAmmo;
    public TextMeshProUGUI totalAmmo;

    public GameObject reloadText;

    public PickupsSpawnerMgr itemSpawnerLeft;
    public PickupsSpawnerMgr itemSpawnerRight;
    public TextMeshProUGUI itemLeftText;
    public TextMeshProUGUI itemRightText;

    public EnemySpawnerMgr enemySpawner;
    public TextMeshProUGUI enemyText;
    private void Start()
    {
     
    }

    public void setAlpha()
    {
        Color col = but.GetComponent<Image>().color;
        col.a = 0.25f;
        but.GetComponent<Image>().color = col;
    }

    private void Update()
    {
        GetCurrentFill();
        if (player.hasPrimary && player.onPrimaryWep == true)
        {
            clipAmmo.text = player.primaryGun.GetComponent<Gun>().currentClip.ToString();
            totalAmmo.text = player.primaryGun.GetComponent<Gun>().currentAmmo.ToString();

            if(player.primaryGun.GetComponent<Gun>().isReloading == true)
            {
                reloadText.SetActive(true);
            }
            else
            {
                reloadText.SetActive(false);
            }
        }
        else if (player.hasSecondary && player.onPrimaryWep == false)
        {
            clipAmmo.text = player.secondaryGun.GetComponent<Gun>().currentClip.ToString();
            totalAmmo.text = player.secondaryGun.GetComponent<Gun>().currentAmmo.ToString();

            if (player.secondaryGun.GetComponent<Gun>().isReloading == true)
            {
                reloadText.SetActive(true);
            }
            else
            {
                reloadText.SetActive(false);
            }
        }

        itemLeftText.text = itemSpawnerLeft.itemsInWorld.Count.ToString();
        itemRightText.text = itemSpawnerRight.itemsInWorld.Count.ToString();
        enemyText.text = enemySpawner.enemyInWorld.Count.ToString();
    }

    public void gunCheck()
    {
        if(player.primaryGun != null)
        {
            if (player.primaryGun.GetComponent<Gun>().gunType == GunType.RifleGunType)
            {
                primaryButton.sprite = gunImages[0];
            }
            else if (player.primaryGun.GetComponent<Gun>().gunType == GunType.ShotgunGunType)
            {
                primaryButton.sprite = gunImages[1];
            }
            else
            {
            }
        }

        if(player.secondaryGun != null)
        {
            if (player.secondaryGun.GetComponent<Gun>().gunType == GunType.PistolGunType)
            {
                secondaryButton.sprite = gunImages[2];
            }
            else
            {
            }
        }
    
    }

    void GetCurrentFill()
    {
        current = player.playerhealth;
        float fillAmount = (float)current / (float)maximum;
        Mask.fillAmount = fillAmount;
        if(current > maximum)
        {
            current = maximum;
        }
        if(current < 0)
        {
            current = 0;
        }
    }
}
