using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void StartGame(String gameMode)
    {
        if (gameMode == "Singleplayer")
        {
            Debug.Log("Starting Singleplayer");
            
            // load new scene here
        } else if (gameMode == "Multiplayer")
        {
            Debug.Log("Starting Multiplayer");
            // load new scene here
        }
    }
}
