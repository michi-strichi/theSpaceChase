using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartSingleplayer()
    {
        Debug.Log("Started Singleplayer Game");
        SceneManager.LoadScene("Singleplayer");
    }

    public void StartMultiplayer()
    {
        Debug.Log("Started Multiplayer Game");
        // LOAD MULTIPLAYER SCENE
    }
}
