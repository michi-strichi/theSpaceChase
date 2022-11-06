using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMultiplayer : NetworkBehaviour
{
    //public float time = 0.0f;
    public TextMeshProUGUI timeText;

    
    
    public GameObject HUD;
    public GameObject GameOverScreen;
    public TextMeshProUGUI scoreText;

    private Boolean playing = true;

    public void UpdateUI(float time)
    {
        timeText.text = time.ToString("F2") + "s";
    }

    public void GameOver(float time)
    {
        if (playing)
        {
            HUD.SetActive(false);
            GameOverScreen.SetActive(true);
            scoreText.text = time.ToString("F2");
            playing = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsPlaying()
    {
        return playing;
    }
}
