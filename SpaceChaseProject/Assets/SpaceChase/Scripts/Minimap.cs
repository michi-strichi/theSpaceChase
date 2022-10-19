using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform gamePlanetsParent;
    public Transform gamePlayer;
    public GameObject miniPlanetsPrefab;
    public GameObject miniPlayerPrefab;
    public Transform minimapPosition;

    private List<Transform> gamePlanets = new List<Transform>();
    private List<Transform> miniPlanets;
    private GameObject miniPlayer;

    void Start()
    {
        for (int i = 0; i < gamePlanetsParent.childCount; i++)
        {
            gamePlanets.Add(gamePlanetsParent.GetChild(i));
        }
        
        // create mini planets at correct position in ui
        foreach (Transform gamePlanet in gamePlanets)
        {
            var miniPlanet = Instantiate(miniPlanetsPrefab);
            miniPlanet.transform.localPosition = gamePlanet.localPosition;
            miniPlanet.transform.parent = transform;
        }
        
        // create mini player at correct position in ui
        miniPlayer = Instantiate(miniPlayerPrefab);
        miniPlayer.transform.localPosition = gamePlayer.localPosition;
        miniPlayer.transform.parent = transform;
        
        transform.localScale *= 0.006f;
    }

    private void Update()
    {
        miniPlayer.transform.localPosition = gamePlayer.transform.position;
        transform.position = minimapPosition.position;


    }
    
}