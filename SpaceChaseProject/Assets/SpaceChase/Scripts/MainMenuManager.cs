using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartSingleplayer(String difficulty)
    {
        Debug.Log("Started Singleplayer Game");
        switch (difficulty)
        {
            case "easy":
                break;
            case "normal":
                break;
            case "hard":
                break;
            default:
                Debug.Log("No string given in function call! pass 'easy', 'normal' or 'hard'");
                break;
        }
    }

    public void StartMultiplayer()
    {
        Debug.Log("Started Multiplayer Game");
    }
}
