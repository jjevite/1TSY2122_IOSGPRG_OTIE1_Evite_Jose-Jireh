using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameMgr : MonoBehaviour
{
    bool gameEnded = false;
    public GameObject  player;
    public GameObject canvas;

    // Meter Var
    public int max;
    public int current;
    public Image mask;

    // Life and Score Output
    public TextMeshProUGUI lives;
    public TextMeshProUGUI score;
    public int scoreCount;
    

    // swing sword  and megaDash button
    public GameObject swingSwordIcon;
    public GameObject megaDashigerIcon;

    public bool keepCount = true;
    public float bossScoreSpawnerCount;

    private void Start()
    {
        if(player.GetComponent<Player>().colorInt == 2)
        {
            current += 100;
        }
    }

    private void Update()
    {
        if(keepCount == true)
        {
            bossScoreSpawnerCount += Time.deltaTime;
        }
     
      
        if(bossScoreSpawnerCount > 10)
        {
            keepCount = false;
            bossScoreSpawnerCount = 0;
            FindObjectOfType<SpawnerManager>().keepSpawning = false;
            FindObjectOfType<SpawnerManager>().SpawnBoss();
        }

        if (current > 49)
        {
            swingSwordIcon.SetActive(true);
        }
        else 
        {
            swingSwordIcon.SetActive(false);
        }
        if(current == 100)
        {
            megaDashigerIcon.SetActive(true);
        }
        else
        {
            megaDashigerIcon.SetActive(false);
        }

        
        
        previewLyf();
        ShowMeter();
        previewScore();
    }

    public void previewLyf()
    {
        lives.text = player.GetComponent<Player>().life.ToString();
    }

    public void previewScore()
    {
        score.text = scoreCount.ToString();
    }

    public void ShowMeter()
    {
        float amount = (float)current / (float)max;
        mask.fillAmount = amount;
    }

    public void addToMeter(int value)
    {
        current += value;
        if(current > max)
        {
            current = max;
        }
    }
    public void EndGame()
    {

        if (gameEnded == false)
        {
            gameEnded = true;
            player.SetActive(false);
            canvas.SetActive(true);
        }
    }

    public void CharSelection()
    {
        SceneManager.LoadScene(0);
    }

   



    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
