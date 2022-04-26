using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharSelection : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] text;
    public int charIndex = 0;

    public void NextCharacter()
    {
        characters[charIndex].SetActive(false);
        text[charIndex].SetActive(false);
        charIndex = (charIndex + 1) % characters.Length;
        characters[charIndex].SetActive(true);
        text[charIndex].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[charIndex].SetActive(false);
        text[charIndex].SetActive(false);
        charIndex--;
        if(charIndex < 0)
        {
            charIndex += characters.Length;
        }
        characters[charIndex].SetActive(true);
        text[charIndex].SetActive(true);

    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedChar", charIndex);
        SceneManager.LoadScene(1);
    }
}
