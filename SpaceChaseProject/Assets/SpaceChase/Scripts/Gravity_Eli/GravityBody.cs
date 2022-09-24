using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    private GameObject[] planets;
    private List<GravityAttractor> planetGravityAttractors = new List<GravityAttractor>();

    private void Awake()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in planets)
        {
            var gravityAttractor = planet.GetComponent<GravityAttractor>();
            planetGravityAttractors.Add(gravityAttractor);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < planetGravityAttractors.Count; i++)
        {
            var distance = (planets[i].transform.position - gameObject.transform.position).magnitude;
            var gravity = -(1/distance)*500;
            planetGravityAttractors[i].Attract(transform, gravity);
        }
    }
}