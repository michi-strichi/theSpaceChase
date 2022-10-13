using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneManagerSingleplayer : MonoBehaviour
{
    public BoidManager boidManager;
    public Spawner boidSpawner;
    public BoidSettings boidSettings_easy;
    public BoidSettings boidSettings_normal;
    public BoidSettings boidSettings_hard;

    public float time = 0.0f;
    public TextMeshProUGUI timeText;
    void Awake()
    {
        String difficulty = "easy";
        
        var container = GameObject.Find("GlobalVariablesContainer");
        if (container != null)
        {
            difficulty = container.GetComponent<VariableContainer>().difficulty;

        }

        switch (difficulty)
        {
            case "easy":
                Debug.Log("Loaded Easy Singleplayer Game");
                boidManager.settings = boidSettings_easy;
                boidSpawner.spawnCount = 30;
                break;
            case "normal":
                Debug.Log("Loaded Normal Singleplayer Game");
                boidManager.settings = boidSettings_normal;
                boidSpawner.spawnCount = 100;
                break;
            case "hard":
                Debug.Log("Loaded Hard Singleplayer Game");
                boidManager.settings = boidSettings_hard;
                boidSpawner.spawnCount = 200;
                break;
        }
    }
    
    void Update()
    {
        Debug.Log(time);
        time += Time.deltaTime;
        //time.ToString("F2")
        timeText.text = time.ToString("F2") + "s";
    }
}
