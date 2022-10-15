using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldManager : MonoBehaviour
{
    public GameObject planet;

    private void OnTriggerEnter(Collider other)
    {
        planet.GetComponent<GravityAttractor>().gravity = -80f;
    }
    
    private void OnTriggerExit(Collider other)
    {
        planet.GetComponent<GravityAttractor>().gravity = 0f;
    }
}